﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PontoCerto.Domain.Commands.Empresa;
using PontoCerto.Domain.Notifications;
using PontoCerto.Domain.Services;
using PontoCerto.WebApplication.Infrastructure.Extensions;
using PontoCerto.WebApplication.Infrastructure.Helpers;
using PontoCerto.WebApplication.Infrastructure.Helpers.Models;
using PontoCerto.WebApplication.Models.Empresa;

namespace PontoCerto.WebApplication.Controllers;

[Authorize(Roles = "admin,empresa")]
public class EmpresaController : Controller
{
    private readonly IEmpresaService _empresaService;
    private readonly INotificator _notificator;
    private readonly ICsvHelper<RegistrarColaboradorCsv> _registrarColaboradorCsvHelper;
    private readonly ILogger<EmpresaController> _logger;

    public EmpresaController(
        IEmpresaService empresaService, 
        INotificator notificator, 
        ICsvHelper<RegistrarColaboradorCsv> registrarColaboradorCsvHelper, 
        ILogger<EmpresaController> logger)
    {
        _empresaService = empresaService;
        _notificator = notificator;
        _registrarColaboradorCsvHelper = registrarColaboradorCsvHelper;
        _logger = logger;
    }

    public async Task<IActionResult> Colaboradores()
    {
        try
        {
            var usuarioId = User.GetLoggedInUserId<string>();

            var empresaId = await _empresaService.ObterId(usuarioId);

            ViewBag.EmpresaId = empresaId;
        
            var queryResult = await _empresaService.ObterColaboradores(empresaId);

            var viewModel = queryResult.Colaboradores.Select(x => new ColaboradorVm(x.Nome, x.DataNascimento, x.Email, x.UserName));
        
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
    public async Task<IActionResult> RegistrarColaborador(RegistrarColaboradorInputModel inputModel)
    {
        if (!ModelState.IsValid)
        {
            return View(inputModel);
        }

        var usuarioId = User.GetLoggedInUserId<string>();

        var empresaId = await _empresaService.ObterId(usuarioId);

        var command = new RegistrarColaboradorCommand(inputModel.PrimeiroNome, inputModel.UltimoNome,
            inputModel.DataNascimento, inputModel.Email, empresaId);

        await _empresaService.RegistrarColaborador(command);

        if (!_notificator.HaveNotifications())
        {
            return RedirectToAction(nameof(Colaboradores));
        }
        
        foreach (var (key, value) in _notificator.GetDictionary())
        {
            ModelState.AddModelError(key, value);
        }

        return View(inputModel);
    }

    [HttpPost]
    public async Task<IActionResult> RegistrarColaboradores(RegistrarColaboradoresInputModel inputModel)
    {
        try
        {
            if (inputModel.Arquivo.Length > 0)
            {
                var filePath = Path.GetTempFileName();

                await using var stream = System.IO.File.Create(filePath);
                await inputModel.Arquivo.CopyToAsync(stream);
            }

            var csv = _registrarColaboradorCsvHelper.GetRecords(inputModel.Arquivo);
    
            var colaboradores = csv.Select(x => new RegistrarColaboradorCommand(
                x.Nome, x.Sobrenome, x.DataNascimento, x.Email, inputModel.EmpresaId));
    
            await _empresaService.RegistrarColaboradores(colaboradores);

            return RedirectToAction(nameof(Colaboradores));

        }
        catch (Exception e)
        {
            _logger.LogError(e, "Falha ao tentar importar planilha csv de colaboradores");
            return StatusCode(500);
        }
    }
}