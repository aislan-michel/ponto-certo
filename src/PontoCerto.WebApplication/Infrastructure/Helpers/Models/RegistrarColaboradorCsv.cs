using CsvHelper.Configuration.Attributes;

namespace PontoCerto.WebApplication.Infrastructure.Helpers.Models;

[Delimiter(";")] 
public class RegistrarColaboradorCsv
{
    [Name("Login")]
    public string UserName { get; set; }
    
    [Name("Nome")]
    public string Nome { get; set; }
    
    [Name("Sobrenome")]
    public string Sobrenome { get; set; }
    
    [Name("Data de nascimento (dd/mm/aaaa)")]
    public string DataNascimento { get; set; }
    
    [Name("E-mail")]
    public string Email { get; set; }
    
    [Name("Cargo")]
    public string Cargo { get; set; }
}