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

    public string Id { get; set; }
    public string UserName { get; set; }
    public string RawPassword { get; set; }
    public string Role { get; set; }
}