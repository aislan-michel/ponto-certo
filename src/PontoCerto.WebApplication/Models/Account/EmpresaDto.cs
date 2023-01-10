using System.ComponentModel.DataAnnotations;

namespace PontoCerto.WebApplication.Models.Account;

public class EmpresaDto : RegisterDto
{
    [Required(ErrorMessage = "Campo obrigatório"), Display(Name = "Nome ou Razão Social")]
    public string Nome { get; set; }
    
    [Required(ErrorMessage = "Campo obrigatório"), StringLength(8), Display(Name = "CNPJ")]
    public string Cnpj { get; set; }
    
    [Range(2, int.MaxValue, ErrorMessage = "Valor inválido"), Display(Name = "Quantidade de funcionários")]
    public int QuantidadeFuncionarios { get; set; }
}