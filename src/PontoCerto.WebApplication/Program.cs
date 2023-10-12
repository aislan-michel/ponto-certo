using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using PontoCerto.Domain.Entities;
using PontoCerto.Domain.Notifications;
using PontoCerto.Domain.Repositories;
using PontoCerto.Domain.Services;
using PontoCerto.WebApplication.Infrastructure;
using PontoCerto.WebApplication.Infrastructure.Helpers;
using PontoCerto.WebApplication.Infrastructure.Repositories;
using PontoCerto.WebApplication.Infrastructure.Security;
using PontoCerto.WebApplication.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MyDbContext>(options =>
{
    const string connection = "server=localhost;port=3308;userid=root;password=numsey;database=ponto-certo";

    options.UseMySql(connection, ServerVersion.AutoDetect(connection));
});

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.SignIn.RequireConfirmedEmail = false;
}).AddEntityFrameworkStores<MyDbContext>().AddDefaultTokenProviders();

builder.Services.AddScoped<IEmpresaService, EmpresaService>();
builder.Services.AddScoped<IColaboradorSerivce, ColaboradorService>();
builder.Services.AddScoped<IAdminService, AdminService>();

builder.Services.AddScoped<IEmpresaRepository, EmpresaRepository>();
builder.Services.AddScoped<IColaboradorRepository, ColaboradorRepository>();
builder.Services.AddScoped<IRegistroDePontoRepository, RegistroDePontoRepository>();

builder.Services.AddScoped<IIdentityService, IdentityService>();
builder.Services.AddScoped<INotificator>(x => new Notificator(new List<Notification>(0)));
builder.Services.AddScoped(typeof(ICsvHelper<>), typeof(CsvHelper<>));

builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddHttpContextAccessor();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

    options.LoginPath = "/Account/SignIn";
    //options.AccessDeniedPath = "/Account/AccessDenied";
    options.SlidingExpiration = true;
});

builder.Services.Configure<PasswordHasherOptions>(options =>
{
    options.CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV3;
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<MyDbContext>();

    var pendingMigrations = await context.Database.GetPendingMigrationsAsync();

    if (pendingMigrations.Any())
    {
        await context.Database.MigrateAsync();

        const string empresa = "empresa";
        const string admin = "admin";
        const string colaborador = "colaborador";
        
        context.Roles.AddRange(new List<IdentityRole>(3)
        {
            new(empresa){NormalizedName = empresa.ToUpper()},
            new(admin){NormalizedName = admin.ToUpper()},
            new(colaborador){NormalizedName = colaborador.ToUpper()}
        });

        await context.SaveChangesAsync();

        var identityUser = new IdentityUser("ponto.certo@admin");

        var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
        
        await userManager.CreateAsync(identityUser, "Teste@123");
        await userManager.AddToRoleAsync(identityUser, admin);

        var usuario = await userManager.FindByNameAsync("ponto.certo@admin");

        context.Empresas.Add(new Empresa("Ponto Certo Inc.", "00000000000000", 1, usuario.Id));
        
        await context.SaveChangesAsync();
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();