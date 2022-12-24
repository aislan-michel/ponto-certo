namespace PontoCerto.Domain.Entities;

public class RegistroDePonto : Entity
{
    public Guid ColaboradorId { get; private set; }
    public DateTime Registro { get; private set; }
}