using Microsoft.AspNetCore.Mvc;
using PontoCerto.Domain.Commands.Empresa;
using PontoCerto.Domain.Notifications;
using PontoCerto.Domain.Services;
using PontoCerto.WebApplication.Infrastructure.Security;
using PontoCerto.WebApplication.Models.Account;

namespace PontoCerto.WebApplication.Controllers;

public class AccountController : Controller
{
    private readonly IIdentityService _identityService;
    private readonly IEmpresaService _empresaService;
    private readonly INotificator _notificator;
    private readonly ILogger<AccountController> _logger;

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
        return View(new EmpresaInputModel());
    }

    [HttpPost]
    public async Task<IActionResult> RegistrarEmpresa(EmpresaInputModel inputModel)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return View(inputModel);
            }
            
            var command =
                new RegistrarEmpresaCommand(inputModel.UserName, inputModel.Password, 
                    inputModel.Nome, inputModel.Cnpj, inputModel.QuantidadeFuncionarios);
            
            await _empresaService.Registrar(command);

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
        catch (Exception e)
        {
            _logger.LogError(e, "Falha ao cadastrar empresa");
            throw;
        }
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