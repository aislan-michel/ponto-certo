namespace PontoCerto.Domain.Commands.Empresa;

public class RegistrarGerenteCommand
{
    public RegistrarGerenteCommand(string username, string senha, string primeiroNome, string ultimoNome, string dataNascimento, string email, string empresaId, string cargoId)
    {
        Username = username;
        Senha = senha;
        PrimeiroNome = primeiroNome;
        UltimoNome = ultimoNome;
        DataNascimento = Convert.ToDateTime(dataNascimento);
        Email = email;
        EmpresaId = empresaId;
        CargoId = cargoId;
    }

    public string Username { get; set; }
    public string Senha { get; set; }
    public string PrimeiroNome { get; set; }
    public string UltimoNome { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Email { get; set; }
    public string EmpresaId { get; set; }
    public string CargoId { get; set; }
}