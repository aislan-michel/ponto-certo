namespace PontoCerto.Domain.Commands.Account;

public class RegistrarEmpresaCommand
{
    public RegistrarEmpresaCommand(string nome, string cnpj, int quantidadeFuncionarios)
    {
        Nome = nome;
        Cnpj = cnpj;
        QuantidadeFuncionarios = quantidadeFuncionarios;
    }

    public string Nome { get; set; }
    public string Cnpj { get; set; }
    public int QuantidadeFuncionarios { get; set; }
}