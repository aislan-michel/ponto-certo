using System.ComponentModel.DataAnnotations;
using PontoCerto.WebApplication.ValidationAttributes;

namespace PontoCerto.WebApplication.Models.Empresa;

public class RegistrarColaboradorDto
{
    [Required(ErrorMessage = "Campo obrigatório"), Display(Name = "Nome")]
    public string PrimeiroNome { get; set; }
    
    [Required(ErrorMessage = "Campo obrigatório"),Display(Name = "Sobrenome")]
    public string UltimoNome { get; set; }
    
    [Required(ErrorMessage = "Campo obrigatório"), Display(Name = "Data de nascimento"), DateTimeMinValue(ErrorMessage = "Valor inválido")]
    public string DataNascimento { get; set; } 
    
    [EmailAddress(ErrorMessage = "Valor inválido"), Required(ErrorMessage = "Campo obrigatório"), Display(Name = "E-mail utilzado pelo colaborador")]
    public string Email { get; set; }
}