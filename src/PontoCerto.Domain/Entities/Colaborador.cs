using PontoCerto.Domain.ValueObjects;

namespace PontoCerto.Domain.Entities;

public class Colaborador
{
    protected Colaborador()
    {
        
    }
    
    public Colaborador(Nome nome, DateTime dataNascimento, string email, Guid empresaId, Guid usuarioId)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        DataNascimento = dataNascimento;
        Email = email;
        EmpresaId = empresaId;
        UsuarioId = usuarioId;
    }

    public Guid Id { get; private set; }
    public Nome Nome { get; private set; }
    public DateTime DataNascimento { get; private set; }
    public string Email { get; private set; }
    public Guid EmpresaId { get; private set; }
    public Guid UsuarioId { get; set; }
}