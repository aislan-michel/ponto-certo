namespace PontoCerto.Domain.Entities;

public class Cargo
{
    protected Cargo()
    {
        
    }
    
    public Cargo(string nome)
    {
        Id = Guid.NewGuid().ToString();
        Nome = nome;
    }

    public string Id { get; private set; } = string.Empty;
    public string Nome { get; private set; } = string.Empty;
    public virtual IEnumerable<Colaborador> Colaboradores { get; private set; }
}