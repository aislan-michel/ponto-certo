namespace PontoCerto.Domain.Entities;

//só o colaborador registra o ponto?
//se sim, a validação pode ficar na dto *
//se não, a validação pode ficar no dominio
public class RegistroDePonto 
{
    protected RegistroDePonto()
    {
        
    }
    
    public RegistroDePonto(Guid colaboradorId, DateTime registro)
    {
        Id = Guid.NewGuid();
        ColaboradorId = colaboradorId;
        Registro = registro;
    }

    public Guid Id { get; private set; }
    public Guid ColaboradorId { get; private set; } = Guid.Empty;
    public DateTime Registro { get; private set; } = DateTime.MinValue;
}