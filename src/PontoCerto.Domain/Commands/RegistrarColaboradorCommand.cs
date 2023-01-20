namespace PontoCerto.Domain.Commands;

public class RegistrarColaboradorCommand
{
    public RegistrarColaboradorCommand(string primeiroNome, string ultimoNome, DateTime dataNascimento, string email, Guid empresaId)
    {
        PrimeiroNome = primeiroNome;
        UltimoNome = ultimoNome;
        DataNascimento = dataNascimento;
        Email = email;
        EmpresaId = empresaId;
    }

    public string PrimeiroNome { get; set; }
    public string UltimoNome { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Email { get; set; }
    public Guid EmpresaId { get; set; }
}