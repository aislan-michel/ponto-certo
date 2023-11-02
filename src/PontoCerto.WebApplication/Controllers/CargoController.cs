using Microsoft.AspNetCore.Mvc;
using PontoCerto.Domain.Repositories;

namespace PontoCerto.WebApplication.Controllers;

public class CargoController : Controller
{
    private readonly ICargoRepository _cargoRepository;

    public CargoController(ICargoRepository cargoRepository)
    {
        _cargoRepository = cargoRepository;
    }

    public async Task<IActionResult> Obter()
    {
        return Json(await _cargoRepository.GetDataAsync(default, default));
    }
}