namespace PontoCerto.WebApplication.Models.Admin;

public class PerfilDeAcessoViewModel
{
    public PerfilDeAcessoViewModel(string id, string? nome)
    {
        Id = id;
        Nome = nome ?? string.Empty;
    }

    public string Id { get; private set; }
    public string Nome { get; private set; }
}