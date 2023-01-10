namespace PontoCerto.Domain.Commands;

public class RegistrarEmpresaCommand
{
    public RegistrarEmpresaCommand(string userName, string senha, string nome, string cnpj, int quantidadeFuncionarios)
    {
        UserName = userName;
        Senha = senha;
        Nome = nome;
        Cnpj = cnpj;
        QuantidadeFuncionarios = quantidadeFuncionarios;
    }

    public string UserName { get; set; }
    public string Senha { get; set; }
    public string Nome { get; set; }
    public string Cnpj { get; set; }
    public int QuantidadeFuncionarios { get; set; }
}