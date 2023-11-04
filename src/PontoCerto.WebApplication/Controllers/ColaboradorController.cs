using Microsoft.AspNetCore.Mvc;
using PontoCerto.Domain.Commands.Colaborador;
using PontoCerto.Domain.Notifications;
using PontoCerto.Domain.Services;
using PontoCerto.WebApplication.Infrastructure.Extensions;
using PontoCerto.WebApplication.Models.Colaborador;

namespace PontoCerto.WebApplication.Controllers;

public class ColaboradorController : Controller
{
    private readonly ILogger<ColaboradorController> _logger;
    private readonly IColaboradorSerivce _colaboradorSerivce;
    private readonly INotificator _notificator;

    public ColaboradorController(
        ILogger<ColaboradorController> logger,
        IColaboradorSerivce colaboradorSerivce,
        INotificator notificator)
    {
        _logger = logger;
        _colaboradorSerivce = colaboradorSerivce;
        _notificator = notificator;
    }

    [HttpGet]
    public IActionResult EfetuarRegistro()
    {
        var usuarioId = User.GetLoggedInUserId();

        var userName = User.GetLoggedInUserName();
        
        return View(new EfetuarRegistroInputModel(usuarioId, userName));
    }
    
    [HttpPost]
    public async Task<IActionResult> EfetuarRegistro(EfetuarRegistroInputModel inputModel)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return View(inputModel);
            }

            await _colaboradorSerivce.EfetuarRegistroDePonto(new EfetuarRegistroDePontoCommand(inputModel.UsuarioId, inputModel.UserName, inputModel.Marcacao));
            
            if (!_notificator.HaveNotifications())
            {
                return RedirectToAction(nameof(MeusRegistros));
            }
        
            foreach (var (key, value) in _notificator.GetDictionary())
            {
                ModelState.AddModelError(key, value);
            }

            return View(inputModel);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Falha ao efetuar registro de ponto pelo colaborador");
            throw;
        }
    }

    public async Task<IActionResult> MeusRegistros()
    {
        var colaboradorId = User.ObterColaboradorId();
        
        return View(await _colaboradorSerivce.MeusRegistrosDePonto(colaboradorId));
    }
}