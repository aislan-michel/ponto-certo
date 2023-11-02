using System.ComponentModel.DataAnnotations;

namespace PontoCerto.WebApplication.Models.Account;

public class RegistrarGerenteInputModel
{
    [Required(ErrorMessage = "Campo obrigatório"), Display(Name = "Login")]
    public string UserName { get; set; }
    
    [Required(ErrorMessage = "Campo obrigatório"), Display(Name = "Senha")]
    public string Password { get; set; }
    
    [Required(ErrorMessage = "Campo obrigatório"), Display(Name = "Nome")]
    public string Nome { get; set; }
    
    [Required(ErrorMessage = "Campo obrigatório"), Display(Name = "Sobrenome")]
    public string Sobrenome { get; set; } 
    
    [Required(ErrorMessage = "Campo obrigatório"), Display(Name = "Data de nascimento")]
    public string DataNascimento { get; set; }
    
    [Required(ErrorMessage = "Campo obrigatório"), Display(Name = "E-mail")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "Campo obrigatório"), Display(Name = "Cargo")]
    public string Cargo { get; set; }
}