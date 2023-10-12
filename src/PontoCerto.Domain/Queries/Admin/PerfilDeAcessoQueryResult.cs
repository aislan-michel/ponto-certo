namespace PontoCerto.Domain.Queries.Admin;

public class PerfilDeAcessoQueryResult
{
    public PerfilDeAcessoQueryResult(IEnumerable<PerfilDeAcessoVm> perfisDeAcesso)
    {
        PerfisDeAcesso = perfisDeAcesso;
    }
    
    public IEnumerable<PerfilDeAcessoVm> PerfisDeAcesso { get; private set; } = Enumerable.Empty<PerfilDeAcessoVm>();
}

public class PerfilDeAcessoVm
{
    public PerfilDeAcessoVm(string id, string? nome)
    {
        Id = id;
        Nome = nome ?? string.Empty;
    }

    public string Id { get; private set; }
    public string Nome { get; private set; }
}