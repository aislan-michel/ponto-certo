using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PontoCerto.Domain.Services;
using PontoCerto.WebApplication.Infrastructure.Extensions;

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
}