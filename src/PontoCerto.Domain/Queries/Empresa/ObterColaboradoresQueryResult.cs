namespace PontoCerto.Domain.Queries.Empresa;

public class ObterColaboradoresQueryResult
{
    public List<ColaboradorDto> Colaboradores { get; private set; } = new();
}

public class ColaboradorDto
{
    public ColaboradorDto(string nome, string dataNascimento, string email, string userName)
    {
        Nome = nome;
        DataNascimento = dataNascimento;
        Email = email;
        UserName = userName;
    }
        
    public string Nome { get; private set; }
    public string DataNascimento { get; private set; }
    public string Email { get; private set; }
    public string UserName { get; private set; }
}

