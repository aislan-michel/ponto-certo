using CsvHelper.Configuration.Attributes;

namespace PontoCerto.WebApplication.Infrastructure.Helpers.Models;

[Delimiter(";")] 
public class RegistrarColaboradorCsv
{
    public RegistrarColaboradorCsv(string nome, string sobrenome, string dataNascimento, string email)
    {
        Nome = nome;
        Sobrenome = sobrenome;
        DataNascimento = dataNascimento;
        Email = email;
    }

    [Index(0)]
    public string Nome { get; set; }
    
    [Index(1)]
    public string Sobrenome { get; set; }
    
    [Name("Data de nascimento (dd/mm/aaaa)")]
    public string DataNascimento { get; set; }
    
    [Name("E-mail")]
    public string Email { get; set; }
}