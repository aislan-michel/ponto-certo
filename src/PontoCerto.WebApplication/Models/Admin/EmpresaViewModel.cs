namespace PontoCerto.WebApplication.Models.Admin;

public class EmpresaViewModel
{
    public EmpresaViewModel(string nome, string cnpj, int quantidadeFuncionarios)
    {
        Nome = nome;
        Cnpj = cnpj;
        QuantidadeFuncionarios = quantidadeFuncionarios;
    }

    public string Nome { get; private set; }
    public string Cnpj { get; private set; }
    public int QuantidadeFuncionarios { get; private set; }
}