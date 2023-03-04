namespace PontoCerto.Domain.Entities;

public class Usuario
{
    protected Usuario()
    {
        
    }
    
    public Usuario(string userName, string rawPassword, string role)
    {
        UserName = userName;
        RawPassword = rawPassword;
        Role = role;
    }

    public string Id { get; private set; } = string.Empty;
    public string UserName { get; private set; }
    public string RawPassword { get; private set; }
    public string Role { get; private set; }
}