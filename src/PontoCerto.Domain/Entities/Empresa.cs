using PontoCerto.Domain.ValueObjects;

namespace PontoCerto.Domain.Entities;

public class Empresa : Entity
{
    public Empresa(
        string nome, string razaoSocial, string cnpj, Endereco endereco, int quantidadeFuncionarios, IEnumerable<string> emails)
    {
        Nome = nome;
        RazaoSocial = razaoSocial;
        Cnpj = cnpj;
        Endereco = endereco;
        QuantidadeFuncionarios = quantidadeFuncionarios;
        Emails = emails;
    }

    public string Nome { get; private set; }
    public string RazaoSocial { get; private set; }
    public string Cnpj { get; private set; }
    public Endereco Endereco { get; private set; }
    public int QuantidadeFuncionarios { get; private set; }
    public IEnumerable<string> Emails { get; private set; }
    public string Segmento { get; private set; }
    public IEnumerable<Colaborador> Colaboradores { get; private set; }
}