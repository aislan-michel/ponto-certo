namespace PontoCerto.Domain.Queries.Colaborador;

public class MeusRegistrosDePontoQueryResult
{
    public MeusRegistrosDePontoQueryResult(IEnumerable<RegistroDePontoDto> registrosDePonto)
    {
        RegistrosDePonto = registrosDePonto;
    }
    
    public IEnumerable<RegistroDePontoDto> RegistrosDePonto { get; private set; }
}

public class RegistroDePontoDto
{
    public RegistroDePontoDto(string colaborador, DateTime registro)
    {
        Colaborador = colaborador;
        Registro = registro;
    }

    public string Colaborador { get; private set; }
    public DateTime Registro { get; private set; } 
}