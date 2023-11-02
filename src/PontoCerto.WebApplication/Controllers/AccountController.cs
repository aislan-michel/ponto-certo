using Microsoft.AspNetCore.Mvc;
using PontoCerto.Domain.Commands.Empresa;
using PontoCerto.Domain.Notifications;
using PontoCerto.Domain.Services;
using PontoCerto.Domain.ValueObjects;
using PontoCerto.WebApplication.Infrastructure.Security;
using PontoCerto.WebApplication.Models.Account;

namespace PontoCerto.WebApplication.Controllers;

public class AccountController : Controller
{
    private readonly IIdentityService _identityService;
    private readonly IEmpresaService _empresaService;
    private readonly INotificator _notificator;
    private readonly ILogger<AccountController> _logger;
    private static RegistrarEmpresaCommand _registrarEmpresaCommand;

    public AccountController(
        IIdentityService identityService, IEmpresaService empresaService,
        INotificator notificator, ILogger<AccountController> logger)
    {
        _identityService = identityService;
        _empresaService = empresaService;
        _notificator = notificator;
        _logger = logger;
    }
    
    [HttpGet]
    public IActionResult RegistrarEmpresa()
    {
        return View(new RegistrarEmpresaInputModel());
    }

    [HttpPost]
    public async Task<IActionResult> RegistrarEmpresa(RegistrarEmpresaInputModel inputModel)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return View(inputModel);
            }
            
            _registrarEmpresaCommand =
                new RegistrarEmpresaCommand(inputModel.Nome, inputModel.Cnpj, inputModel.QuantidadeFuncionarios);

            return RedirectToAction(nameof(RegistrarGerente));
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Falha ao cadastrar empresa");
            throw;
        }
    }
    
    [HttpGet]
    public IActionResult RegistrarGerente()
    {
        return View(new RegistrarGerenteInputModel());
    }

    [HttpPost]
    public async Task<IActionResult> RegistrarGerente(RegistrarGerenteInputModel inputModel)
    {
        if (!ModelState.IsValid)
        {
            return View(inputModel);
        }
        
        await _empresaService.Registrar(_registrarEmpresaCommand);

        var empresa = await _empresaService.ObterEmpresa(_registrarEmpresaCommand.Cnpj);

        var command = new RegistrarGerenteCommand(inputModel.UserName, inputModel.Password, inputModel.Nome, inputModel.Sobrenome, inputModel.DataNascimento,
            inputModel.Email, empresa.Id, inputModel.Cargo);

        await _empresaService.RegistrarGerente(command);
        
        if (!_notificator.HaveNotifications())
        {
            return RedirectToAction(nameof(SignIn));
        }

        foreach (var (key, value) in _notificator.GetDictionary())
        {
            ModelState.AddModelError(key, value);
        }

        return View(inputModel);
    }

    [HttpGet]
    public IActionResult SignIn()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> SignIn(SignInInputModel inputModel)
    {
        if (!ModelState.IsValid)
        {
            return View(inputModel);
        }
        
        await _identityService.SignIn(inputModel.UserName, inputModel.Password);
        
        return RedirectToAction("Index", "Home");
    }
    
    public new async Task<IActionResult> SignOut()
    {
        await _identityService.SignOut();

        return RedirectToAction(nameof(SignIn));
    }
}