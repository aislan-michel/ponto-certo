using Microsoft.AspNetCore.Mvc;
using PontoCerto.Domain.Commands;
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
        return View(new EmpresaDto());
    }

    [HttpPost]
    public async Task<IActionResult> RegistrarEmpresa(EmpresaDto empresaDto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return View(empresaDto);
            }
            
            var command =
                new RegistrarEmpresaCommand(empresaDto.UserName, empresaDto.Password, 
                    empresaDto.Nome, empresaDto.Cnpj, empresaDto.QuantidadeFuncionarios);
            
            await _empresaService.Registrar(command);

            if (!_notificator.HaveNotifications())
            {
                return RedirectToAction(nameof(SignIn));
            }
            
            foreach (var (key, value) in _notificator.GetDictionary())
            {
                ModelState.AddModelError(key, value);
            }

            return View(empresaDto);
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
    public async Task<IActionResult> SignIn(SignInDto dto)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }
        
        await _identityService.SignIn(dto.UserName, dto.Password);
        
        return RedirectToAction("Index", "Home");
    }
    
    public new async Task<IActionResult> SignOut()
    {
        await _identityService.SignOut();

        return RedirectToAction(nameof(SignIn));
    }
}