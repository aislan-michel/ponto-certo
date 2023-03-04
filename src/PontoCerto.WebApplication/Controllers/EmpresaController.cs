using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PontoCerto.Domain.Commands;
using PontoCerto.Domain.Notifications;
using PontoCerto.Domain.Services;
using PontoCerto.WebApplication.Infrastructure.Extensions;
using PontoCerto.WebApplication.Models.Empresa;

namespace PontoCerto.WebApplication.Controllers;

[Authorize(Roles = "admin,empresa")]
public class EmpresaController : Controller
{
    private readonly IEmpresaService _empresaService;
    private readonly INotificator _notificator;
    private readonly ILogger<EmpresaController> _logger;

    public EmpresaController(
        IEmpresaService empresaService, 
        INotificator notificator, 
        ILogger<EmpresaController> logger)
    {
        _empresaService = empresaService;
        _notificator = notificator;
        _logger = logger;
    }

    public async Task<IActionResult> Colaboradores()
    {
        try
        {
            var usuarioId = User.GetLoggedInUserId<string>();

            var empresaId = await _empresaService.ObterId(usuarioId);
        
            var query = await _empresaService.ObterColaboradores(empresaId);

            var viewModel = query.Colaboradores;
        
            return View(viewModel);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Falha ao obter lista de colaboradores");
            throw;
        }
    }

    [HttpGet]
    public IActionResult RegistrarColaborador()
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

        var usuarioId = User.GetLoggedInUserId<string>();

        var empresaId = await _empresaService.ObterId(usuarioId);

        var command = new RegistrarColaboradorCommand(dto.PrimeiroNome, dto.UltimoNome,
            dto.DataNascimento, dto.Email, new Guid(empresaId));

        await _empresaService.RegistrarColaborador(command);

        if (!_notificator.HaveNotifications())
        {
            return RedirectToAction(nameof(Colaboradores));
        }
        
        foreach (var (key, value) in _notificator.GetDictionary())
        {
            ModelState.AddModelError(key, value);
        }

        return View(dto);
    }
}