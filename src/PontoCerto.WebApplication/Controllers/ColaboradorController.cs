using Microsoft.AspNetCore.Mvc;
using PontoCerto.WebApplication.Models.Colaborador;

namespace PontoCerto.WebApplication.Controllers;

public class ColaboradorController : Controller
{
    [HttpGet]
    public IActionResult EfetuarRegistro()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> EfetuarRegistro(EfetuarRegistroDto dto)
    {
        return View();
    }
}