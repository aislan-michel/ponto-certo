using System.ComponentModel.DataAnnotations;

namespace PontoCerto.WebApplication.Models.Account;

public class EmpresaInputModel
{
    [Required(ErrorMessage = "Campo obrigatório")]
    public string UserName { get; set; }
    
    [Required(ErrorMessage = "Campo obrigatório")]
    public string Password { get; set; }
    
    [Required(ErrorMessage = "Campo obrigatório"), Display(Name = "Nome ou Razão Social")]
    public string Nome { get; set; }
    
    [Required(ErrorMessage = "Campo obrigatório"), StringLength(14), Display(Name = "CNPJ")]
    public string Cnpj { get; set; }
    
    [Range(2, int.MaxValue, ErrorMessage = "Valor inválido, sua empresa deve ter ao menos 2 funcionários"), Display(Name = "Quantidade de funcionários")]
    public int QuantidadeFuncionarios { get; set; }
}