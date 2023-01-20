using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PontoCerto.Domain.Commands;
using PontoCerto.Domain.Services;
using PontoCerto.WebApplication.Infrastructure.Extensions;
using PontoCerto.WebApplication.Models.Empresa;

namespace PontoCerto.WebApplication.Controllers;

[Authorize(Roles = "admin,empresa")]
public class EmpresaController : Controller
{
    private readonly IEmpresaService _empresaService;

    public EmpresaController(IEmpresaService empresaService)
    {
        _empresaService = empresaService;
    }

    public async Task<IActionResult> Colaboradores()
    {
        var empresaId = User.GetLoggedInUserId<string>();
        
        var query = await _empresaService.ObterColaboradores(empresaId);

        var viewModel = query.Colaboradores;
        
        return View(viewModel);
    }

    [HttpGet]
    public async Task<IActionResult> RegistrarColaborador()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> RegistrarColaborador(RegistrarColaboradorDto dto)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }

        var empresaId = User.GetLoggedInUserId<string>();

        var command = new RegistrarColaboradorCommand(dto.PrimeiroNome, dto.UltimoNome,
            dto.DataNascimento, dto.Email, new Guid(empresaId));

        await _empresaService.RegistrarColaborador(command);
        
        return RedirectToAction(nameof(Colaboradores));
    }
}