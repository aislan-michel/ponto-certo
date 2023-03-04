using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PontoCerto.Domain.Repositories;
using PontoCerto.WebApplication.Infrastructure;
using PontoCerto.WebApplication.Models.Admin;

namespace PontoCerto.WebApplication.Controllers;

[Authorize(Roles = "admin")]
public class AdminController : Controller
{
    private readonly IEmpresaRepository _empresaRepository;
    private readonly MyDbContext _dbContext;

    public AdminController(IEmpresaRepository empresaRepository, MyDbContext dbContext)
    {
        _empresaRepository = empresaRepository;
        _dbContext = dbContext;
    }

    public async Task<IActionResult> Empresas()
    {
        var empresas = await _empresaRepository.Obter();

        var dto = empresas.Empresas.Select(x => new EmpresaDto(x.Nome, x.Cnpj, x.QuantidadeFuncionarios, x.UserName));

        return View(dto);
    }
    
    public async Task<IActionResult> PerfisDeAcesso()
    {
        var roles = await _dbContext.Roles.ToListAsync();
        
        return View(roles);
    }
}