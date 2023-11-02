namespace PontoCerto.Domain.Entities;

//só o colaborador registra o ponto?
//se sim, a validação pode ficar na dto *
//se não, a validação pode ficar no dominio
public class RegistroDePonto 
{
    protected RegistroDePonto()
    {
        
    }
    
    public RegistroDePonto(string colaboradorId, DateTime registro)
    {
        Id = Guid.NewGuid().ToString();
        ColaboradorId = colaboradorId;
        Registro = registro;
    }

    public string Id { get; private set; } = string.Empty;
    public string ColaboradorId { get; private set; } = string.Empty;
    public virtual Colaborador Colaborador { get; set; }
    public DateTime Registro { get; private set; } = new DateTime();
}