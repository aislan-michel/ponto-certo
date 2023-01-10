using PontoCerto.Domain.ValueObjects;

namespace PontoCerto.Domain.Entities;

public class Colaborador
{
    public Guid Id { get; private set; }
    public Nome Nome { get; private set; }
    public DateTime DataNascimento { get; private set; }
    public string Email { get; private set; }
    public Guid EmpresaId { get; private set; }
    public Guid UsuarioId { get; set; }
}