namespace PontoCerto.Domain.ValueObjects;

public struct Endereco
{
    public Endereco(
        string logradouro, string numero, string bairro, string cidade, string estado)
    {
        Logradouro = logradouro;
        Numero = numero;
        Bairro = bairro;
        Cidade = cidade;
        Estado = estado;
    }

    public string Logradouro { get; }
    public string Numero { get; }
    public string Bairro { get; }
    public string Cidade { get; }
    public string Estado { get; }
}