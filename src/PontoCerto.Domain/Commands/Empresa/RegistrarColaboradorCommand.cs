namespace PontoCerto.Domain.Commands.Empresa;

public class RegistrarColaboradorCommand
{
    public RegistrarColaboradorCommand(string primeiroNome, string ultimoNome, string dataNascimento, string email, string empresaId)
    {
        PrimeiroNome = primeiroNome;
        UltimoNome = ultimoNome;
        DataNascimento = Convert.ToDateTime(dataNascimento);
        Email = email;
        EmpresaId = new Guid(empresaId);
    }
    
    public RegistrarColaboradorCommand(string primeiroNome, string ultimoNome, DateTime dataNascimento, string email, string empresaId)
    {
        PrimeiroNome = primeiroNome;
        UltimoNome = ultimoNome;
        DataNascimento = dataNascimento;
        Email = email;
        EmpresaId = new Guid(empresaId);
    }

    public string PrimeiroNome { get; set; }
    public string UltimoNome { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Email { get; set; }
    public Guid EmpresaId { get; set; }
}