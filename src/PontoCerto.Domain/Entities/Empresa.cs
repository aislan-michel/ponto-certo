using PontoCerto.Domain.ValueObjects;

namespace PontoCerto.Domain.Entities;

public class Empresa 
{
    protected Empresa()
    {
        
    }

    public Empresa(Guid id, string nome)
    {
        Id = id.ToString();
        Nome = nome;
    }

    public Empresa(string nome, string cnpj, int quantidadeFuncionarios)
    {
        Id = Guid.NewGuid().ToString();
        Nome = nome;
        Cnpj = cnpj;
        QuantidadeFuncionarios = quantidadeFuncionarios;
    }

    public string Id { get; private set; } = string.Empty;
    public string Nome { get; private set; } = string.Empty;
    public string Cnpj { get; set; } = string.Empty;
    public int QuantidadeFuncionarios { get; private set; } = 0;
    public string? Segmento { get; private set; } = null;
    public Contato Contato { get; private set; } = new();
    public Endereco Endereco { get; private set; } = new();
    public IEnumerable<Colaborador> Colaboradores { get; private set; }
}