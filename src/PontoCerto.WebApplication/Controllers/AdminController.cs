using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PontoCerto.Domain.Repositories;
using PontoCerto.Domain.Services;
using PontoCerto.WebApplication.Infrastructure;
using PontoCerto.WebApplication.Models.Admin;

namespace PontoCerto.WebApplication.Controllers;

[Authorize(Roles = "admin")]
public class AdminController : Controller
{
    private readonly IAdminService _adminService;

    public AdminController(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public async Task<IActionResult> Empresas()
    {
        var queryResult = await _adminService.ObterEmpresas();

        var dto = queryResult.Empresas.Select(x => new EmpresaDto(x.Nome, x.Cnpj, x.QuantidadeFuncionarios, x.UserName));

        return View(dto);
    }
    
    public async Task<IActionResult> PerfisDeAcesso()
    {
        var queryResult = await _adminService.ObterPerfisDeAcesso();

        var dto = queryResult.PerfisDeAcesso.Select(x => new PerfilDeAcessoDto(x.Id, x.Nome));
        
        return View(dto);
    }
}