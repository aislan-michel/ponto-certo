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

    public IEnumerable<string> Emails { get; set; }
    public IEnumerable<string> Telefones { get; set; }
}