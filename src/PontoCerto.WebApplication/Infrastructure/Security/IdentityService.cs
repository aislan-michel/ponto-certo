using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using PontoCerto.Domain.Notifications;
using PontoCerto.WebApplication.Infrastructure.Configurations;

namespace PontoCerto.WebApplication.Infrastructure.Security;

public class IdentityService : IIdentityService
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly INotificator _notificator;
    private readonly ILogger<IdentityService> _logger;

    public IdentityService(
        UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,
        INotificator notificator, ILogger<IdentityService> logger)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _notificator = notificator;
        _logger = logger;
    }

    public async Task<string> GetUserId(string userName)
    {
        if (string.IsNullOrWhiteSpace(userName))
        {
            return string.Empty;
        }
        
        var user = await _userManager.FindByNameAsync(userName);

        return user == null ? string.Empty : user.Id;
    }

    public async Task Register(string userName, string password)
    {
        //todo: criar teste
        if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
        {
            _notificator.Add("UserName", "Login inválido");
            _notificator.Add("Password", "Senha inválida");
            return;
        }
        
        var identityUser = new IdentityUser(userName);
        
        var createResult = await _userManager.CreateAsync(identityUser, password);

        if (!createResult.Succeeded)
        {
            var mensagens = string.Join("\n", createResult.Errors.Select(x => $"{x.Code} - {x.Description}")); 
            _logger.LogError("identity lib: {mensagens}", mensagens);
            _notificator.Add("UserName", "Falha ao cadastrar usuário");
            return;
        }

        var addToRoleResult = await _userManager.AddToRoleAsync(identityUser, Roles.Padrao);

        if (!addToRoleResult.Succeeded)
        {
            var mensagens = string.Join("\n", addToRoleResult.Errors.Select(x => $"{x.Code} - {x.Description}")); 
            _logger.LogError("identity lib: {mensagens}", mensagens);
            _notificator.Add("UserName", "Falha ao adicionar permissões do usuário");
        }
    }
    
    public async Task SignIn(string userName, string password)
    {
        var user = await _userManager.FindByNameAsync(userName);

        if (user == null)
        {
            return;
        }

        var addClaimResult = await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Sid, user.Id));

        if (!addClaimResult.Succeeded)
        {
            var mensagens = string.Join("\n", addClaimResult.Errors.Select(x => $"{x.Code} - {x.Description}")); 
            _logger.LogError("identity lib: {mensagens}", mensagens);
            _notificator.Add("UserName", "Falha ao autenticar usuario");
        }

        var passwordSignInResult = await _signInManager.PasswordSignInAsync(userName, password, false, false);

        if (!passwordSignInResult.Succeeded)
        { 
            _notificator.Add("UserName", "login ou senha inválidos");
        }
    }
    
    public async Task SignOut()
    {
        await _signInManager.SignOutAsync();
    }
}