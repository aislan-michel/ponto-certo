namespace PontoCerto.Domain.ValueObjects;

public class Endereco
{
    public Endereco()
    {
        
    }
    
    public Endereco(
        string logradouro, string numero, string bairro, string cidade, string estado,
        string cep)
    {
        Logradouro = logradouro;
        Numero = numero;
        Bairro = bairro;
        Cidade = cidade;
        Estado = estado;
        Cep = cep;
    }

    public string Logradouro { get; }
    public string Numero { get; }
    public string Bairro { get; }
    public string Cidade { get; }
    public string Estado { get; }
    public string Cep { get; set; }
}