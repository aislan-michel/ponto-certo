using System.ComponentModel.DataAnnotations;

namespace PontoCerto.WebApplication.Models.Empresa;

public class RegistrarColaboradoresDto
{
    public string EmpresaId { get; set; }
    
    [Required(ErrorMessage = "Campo obrigatório")]
    public IFormFile Arquivo { get; set; }
}