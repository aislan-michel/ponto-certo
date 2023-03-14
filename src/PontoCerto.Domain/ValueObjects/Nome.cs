namespace PontoCerto.Domain.ValueObjects;

public class Nome
{
    protected Nome()
    {
        
    }
    
    public Nome(string primeiroNome, string ultimoNome)
    {
        PrimeiroNome = primeiroNome;
        UltimoNome = ultimoNome;
    }

    public string PrimeiroNome { get; private set; } = string.Empty;
    public string UltimoNome { get; private set; } = string.Empty;
    public string NomeCompleto => $"{PrimeiroNome} {UltimoNome}";
}