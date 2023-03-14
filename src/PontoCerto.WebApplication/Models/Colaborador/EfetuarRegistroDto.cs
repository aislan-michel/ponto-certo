using System.ComponentModel.DataAnnotations;

namespace PontoCerto.WebApplication.Models.Colaborador;

public class EfetuarRegistroDto
{
    public EfetuarRegistroDto()
    {
        
    }
    
    public EfetuarRegistroDto(string usuarioId, string userName)
    {
        UsuarioId = usuarioId;
        UserName = userName;
        Marcacao = DateTime.Now;
    }

    [Required(ErrorMessage = "Campo obrigatório")]
    public string UsuarioId { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Campo obrigatório")]
    public string UserName { get; set; } = string.Empty;
    
    [Display(Name = "Data/Hora")]
    [Required(ErrorMessage = "Campo obrigatório")]
    public DateTime Marcacao { get; set; }
}