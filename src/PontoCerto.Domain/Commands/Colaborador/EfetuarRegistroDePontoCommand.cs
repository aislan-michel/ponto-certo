namespace PontoCerto.Domain.Commands.Colaborador;

public class EfetuarRegistroDePontoCommand
{
    public EfetuarRegistroDePontoCommand(string usuarioId, string userName, DateTime marcacao)
    {
        UsuarioId = usuarioId;
        UserName = userName;
        Marcacao = marcacao;
    }

    public string UsuarioId { get; private set; }
    public string UserName { get; private set; }
    public DateTime Marcacao { get; private set; }
}