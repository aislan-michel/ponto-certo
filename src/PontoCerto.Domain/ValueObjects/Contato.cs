namespace PontoCerto.Domain.ValueObjects;

public class Contato
{
    public Contato()
    {
        
    }

    public Contato(IEnumerable<string> emails, IEnumerable<string> telefones)
    {
        Emails = emails;
        Telefones = telefones;
    }

    public IEnumerable<string> Emails { get; set; } = new List<string>();
    public IEnumerable<string> Telefones { get; set; } = new List<string>();
}