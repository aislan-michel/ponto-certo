using Microsoft.AspNetCore.Mvc;
using PontoCerto.Domain.Commands.Account;
using PontoCerto.Domain.Notifications;
using PontoCerto.Domain.Services;
using PontoCerto.WebApplication.Models.Account;

namespace PontoCerto.WebApplication.Controllers;

public class AccountController : Controller
{
    private readonly IAccountService _accountService;
    private readonly INotificator _notificator;
    private readonly ILogger<AccountController> _logger;
    private static RegistrarEmpresaCommand _registrarEmpresaCommand = new(default, default, default);

    public AccountController(
        IAccountService accountService, 
        INotificator notificator, ILogger<AccountController> logger)
    {
        _accountService = accountService;
        _notificator = notificator;
        _logger = logger;
    }
    
    [HttpGet]
    public IActionResult RegistrarEmpresa()
    {
        return View(new RegistrarEmpresaInputModel());
    }

    [HttpPost]
    public IActionResult RegistrarEmpresa(RegistrarEmpresaInputModel inputModel)
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
        
        await _accountService.RegistrarEmpresa(_registrarEmpresaCommand);

        var queryResult = await _accountService.ObterEmpresa(_registrarEmpresaCommand.Cnpj);

        var command = new RegistrarGerenteCommand(inputModel.UserName, inputModel.Password, inputModel.Nome, inputModel.Sobrenome, inputModel.DataNascimento,
            inputModel.Email, queryResult.Empresa.Id, inputModel.Cargo);

        await _accountService.RegistrarGerente(command);
        
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
        
        await _accountService.SignIn(inputModel.UserName, inputModel.Password);
        
        return RedirectToAction("Index", "Home");
    }
    
    public new async Task<IActionResult> SignOut()
    {
        await _accountService.SignOut();

        return RedirectToAction(nameof(SignIn));
    }
}