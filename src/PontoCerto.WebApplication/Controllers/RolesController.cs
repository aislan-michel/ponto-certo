using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PontoCerto.WebApplication.Infrastructure;

namespace PontoCerto.WebApplication.Controllers;

[Authorize(Roles = "admin")]
public class RolesController : Controller
{
    private readonly MyDbContext _dbContext;

    public RolesController(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IActionResult> Index()
    {
        var roles = await _dbContext.Roles.ToListAsync();
        
        return View(roles);
    }
}