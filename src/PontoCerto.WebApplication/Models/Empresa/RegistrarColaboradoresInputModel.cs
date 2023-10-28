using System.ComponentModel.DataAnnotations;

namespace PontoCerto.WebApplication.Models.Empresa;

public class RegistrarColaboradoresInputModel
{
    public string EmpresaId { get; set; }
    
    [Required(ErrorMessage = "Campo obrigatório")]
    public IFormFile Arquivo { get; set; }
}