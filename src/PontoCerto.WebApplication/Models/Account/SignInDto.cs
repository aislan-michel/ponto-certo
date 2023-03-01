using System.ComponentModel.DataAnnotations;

namespace PontoCerto.WebApplication.Models.Account;

public class SignInDto
{
    [Required(ErrorMessage = "Campo obrigatório")]
    public string UserName { get; set; }
    
    [Display(Name = "Senha")]
    [Required(ErrorMessage = "Campo obrigatório")]
    public string Password { get; set; }
}