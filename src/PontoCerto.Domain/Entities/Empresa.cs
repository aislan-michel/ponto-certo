using PontoCerto.Domain.ValueObjects;

namespace PontoCerto.Domain.Entities;

public class Empresa 
{
    protected Empresa()
    {
        
    }

    public Empresa(Guid id, string nome)
    {
        Id = id;
        Nome = nome;
    }

    public Empresa(string nome, string cnpj, int quantidadeFuncionarios, string usuarioId)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Cnpj = cnpj;
        QuantidadeFuncionarios = quantidadeFuncionarios;
        UsuarioId = usuarioId;
    }

    public Guid Id { get; private set; }
    public string Nome { get; private set; } = string.Empty;
    public string Cnpj { get; set; } = string.Empty;
    public int QuantidadeFuncionarios { get; private set; }
    public string? Segmento { get; private set; } = null;
    public Contato Contato { get; private set; } = new();
    public Endereco Endereco { get; private set; } = new();
    public IEnumerable<Colaborador> Colaboradores { get; private set; } = new List<Colaborador>();
    public string UsuarioId { get; private set; } = string.Empty;
}