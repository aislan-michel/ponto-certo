namespace PontoCerto.Domain.ValueObjects;

public struct Nome
{
    public Nome(string primeiroNome, string ultimoNome)
    {
        PrimeiroNome = primeiroNome;
        UltimoNome = ultimoNome;
    }

    public string PrimeiroNome { get; private set; }
    public string UltimoNome { get; private set; }
}