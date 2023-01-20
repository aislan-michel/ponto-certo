using System.ComponentModel.DataAnnotations;

namespace PontoCerto.WebApplication.Models.Empresa;

public class RegistrarColaboradorDto
{
    [Display(Name = "Nome")]
    public string PrimeiroNome { get; set; }
    
    [Display(Name = "Sobrenome")]
    public string UltimoNome { get; set; }
    
    [Display(Name = "Data de nascimento")]
    public DateTime DataNascimento { get; set; }
    
    [EmailAddress]
    [Display(Name = "E-mail utilzado pelo colaborador")]
    public string Email { get; set; }
}