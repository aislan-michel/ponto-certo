using System.Security.Claims;

namespace PontoCerto.WebApplication.Infrastructure.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static string GetLoggedInUserId(this ClaimsPrincipal principal)
    {
        if (principal == null)
        {
            throw new ArgumentNullException(nameof(principal));
        }

        var loggedInUserId = principal.FindFirstValue(ClaimTypes.Sid);
        
        return string.IsNullOrWhiteSpace(loggedInUserId) ? string.Empty : loggedInUserId;
    }
    
    public static string GetLoggedInUserName(this ClaimsPrincipal principal)
    {
        if (principal == null)
        {
            throw new ArgumentNullException(nameof(principal));
        }

        var userName = principal.FindFirstValue("UserName");
        
        return string.IsNullOrWhiteSpace(userName) ? string.Empty : userName;
    }
    
    public static string ObterColaboradorId(this ClaimsPrincipal principal)
    {
        if (principal == null)
        {
            throw new ArgumentNullException(nameof(principal));
        }

        var colaboradorId = principal.FindFirstValue("ColaboradorId");
        
        return string.IsNullOrWhiteSpace(colaboradorId) ? string.Empty : colaboradorId;
    }
    
    public static string ObterEmpresaId(this ClaimsPrincipal principal)
    {
        if (principal == null)
        {
            throw new ArgumentNullException(nameof(principal));
        }

        var empresaId = principal.FindFirstValue("EmpresaId");

        return string.IsNullOrWhiteSpace(empresaId) ? string.Empty : empresaId;
    }
    
    public static T ObterCargo<T>(this ClaimsPrincipal principal)
    {
        if (principal == null)
        {
            throw new ArgumentNullException(nameof(principal));
        }

        var cargo = principal.FindFirstValue("Cargo");

        if (typeof(T) == typeof(string))
        {
            return (T)Convert.ChangeType(cargo, typeof(T));
        }

        if (typeof(T) == typeof(int) || typeof(T) == typeof(long))
        {
            return cargo != null ? (T)Convert.ChangeType(cargo, typeof(T)) : (T)Convert.ChangeType(0, typeof(T));
        }

        throw new Exception("Invalid type provided");
    }
}