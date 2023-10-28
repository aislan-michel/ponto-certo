namespace PontoCerto.Domain.Queries.Admin;

public class PerfilDeAcessoQueryResult
{
    public PerfilDeAcessoQueryResult(IEnumerable<PerfilDeAcessoDto> perfisDeAcesso)
    {
        PerfisDeAcesso = perfisDeAcesso;
    }
    
    public IEnumerable<PerfilDeAcessoDto> PerfisDeAcesso { get; private set; }
}

public class PerfilDeAcessoDto
{
    public PerfilDeAcessoDto(string id, string? nome)
    {
        Id = id;
        Nome = nome ?? string.Empty;
    }

    public string Id { get; private set; }
    public string Nome { get; private set; }
}