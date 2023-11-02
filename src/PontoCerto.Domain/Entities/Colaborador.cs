using PontoCerto.Domain.ValueObjects;

namespace PontoCerto.Domain.Entities;

public class Colaborador
{
    protected Colaborador()
    {
        
    }
    
    public Colaborador(Nome nome, DateTime dataNascimento, string email, string empresaId, string usuarioId, string cargoId)
    {
        Id = Guid.NewGuid().ToString();
        Nome = nome;
        DataNascimento = dataNascimento;
        Email = email;
        EmpresaId = empresaId;
        UsuarioId = usuarioId;
        CargoId = cargoId;
    }

    public string Id { get; private set; } = string.Empty;
    public Nome Nome { get; private set; } = new (string.Empty, string.Empty);
    public DateTime DataNascimento { get; private set; } = new DateTime();
    public string Email { get; private set; } = string.Empty;

    public string EmpresaId { get; private set; } = string.Empty;
    public virtual Empresa Empresa { get; private set; }

    public string UsuarioId { get; private set; } = string.Empty;
    public virtual Usuario Usuario { get; private set; }

    public string CargoId { get; private set; } = string.Empty;
    public virtual Cargo Cargo { get; private set; }

    public virtual IEnumerable<RegistroDePonto> RegistrosDePonto { get; private set; }
}