using PontoCerto.Domain.ValueObjects;

namespace PontoCerto.Domain.Entities;

public class Empresa 
{
    protected Empresa()
    {
        
    }

    public Empresa(string nome, string cnpj, int quantidadeFuncionarios, string usuarioId)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Cnpj = cnpj;
        QuantidadeFuncionarios = quantidadeFuncionarios;
        UsuarioId = usuarioId;
    }

    public Guid Id { get; set; }
    public string Nome { get; private set; }
    public string Cnpj { get; private set; }
    public int QuantidadeFuncionarios { get; private set; }
    public string Segmento { get; private set; }
    public Contato Contato { get; private set; }
    public Endereco Endereco { get; private set; }
    public IEnumerable<Colaborador> Colaboradores { get; private set; }
    public string UsuarioId { get; private set; }
}