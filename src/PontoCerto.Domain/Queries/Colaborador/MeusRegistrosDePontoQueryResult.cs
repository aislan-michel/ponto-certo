namespace PontoCerto.Domain.Queries.Colaborador;

public class MeusRegistrosDePontoQueryResult
{
    public IEnumerable<RegistroDePontoVm> RegistrosDePonto { get; set; } = new List<RegistroDePontoVm>();
}

public class RegistroDePontoVm
{
    public RegistroDePontoVm(string colaborador, DateTime registro)
    {
        Colaborador = colaborador;
        Registro = registro;
    }

    public string Colaborador { get; private set; }
    public DateTime Registro { get; private set; } 
}