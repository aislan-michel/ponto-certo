﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PontoCerto.Domain.Services;
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

        var empresas = queryResult.Empresas.Select(x => new EmpresaViewModel(x.Nome, x.Cnpj, x.QuantidadeFuncionarios, x.UserName));

        return View(empresas);
    }
    
    public async Task<IActionResult> PerfisDeAcesso()
    {
        var queryResult = await _adminService.ObterPerfisDeAcesso();

        var perfisDeAcesso = queryResult.PerfisDeAcesso.Select(x => new PerfilDeAcessoViewModel(x.Id, x.Nome));
        
        return View(perfisDeAcesso);
    }
}