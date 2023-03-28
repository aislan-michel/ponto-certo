using Microsoft.AspNetCore.Mvc;
using PontoCerto.Domain.Commands.Colaborador;
using PontoCerto.Domain.Services;
using PontoCerto.WebApplication.Infrastructure.Extensions;
using PontoCerto.WebApplication.Infrastructure.Security;
using PontoCerto.WebApplication.Models.Colaborador;

namespace PontoCerto.WebApplication.Controllers;

public class ColaboradorController : Controller
{
    private readonly ILogger<ColaboradorController> _logger;
    private readonly IIdentityService _identityService;
    private readonly IColaboradorSerivce _colaboradorSerivce;

    public ColaboradorController(
        ILogger<ColaboradorController> logger,
        IIdentityService identityService, 
        IColaboradorSerivce colaboradorSerivce)
    {
        _logger = logger;
        _identityService = identityService;
        _colaboradorSerivce = colaboradorSerivce;
    }

    [HttpGet]
    public async Task<IActionResult> EfetuarRegistro()
    {
        var usuarioId = User.GetLoggedInUserId<string>();

        var userName = await _identityService.GetUserName(usuarioId);
        
        return View(new EfetuarRegistroDto(usuarioId, userName));
    }
    
    [HttpPost]
    public async Task<IActionResult> EfetuarRegistro(EfetuarRegistroDto dto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            await _colaboradorSerivce.EfetuarRegistroDePonto(new EfetuarRegistroDePontoCommand(dto.UsuarioId, dto.UserName, dto.Marcacao));
        
            return RedirectToAction(nameof(MeusRegistros));
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Falha ao efetuar registro de ponto pelo colaborador");
            throw;
        }
    }

    public async Task<IActionResult> MeusRegistros()
    {
        var colaboradorId = User.ObterColaboradorId<string>();
        
        return View(await _colaboradorSerivce.MeusRegistrosDePonto(new Guid(colaboradorId)));
    }
}