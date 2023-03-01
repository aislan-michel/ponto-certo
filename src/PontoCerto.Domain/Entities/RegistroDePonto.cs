namespace PontoCerto.Domain.Entities;

public class RegistroDePonto 
{
    protected RegistroDePonto()
    {
        
    }
    
    public RegistroDePonto(Guid colaboradorId, DateTime registro)
    {
        ColaboradorId = colaboradorId;
        Registro = registro;
    }

    public Guid ColaboradorId { get; private set; }
    public DateTime Registro { get; private set; }
}