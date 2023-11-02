using System.Security.Claims;

namespace PontoCerto.WebApplication.Infrastructure.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static T GetLoggedInUserId<T>(this ClaimsPrincipal principal)
    {
        if (principal == null)
        {
            throw new ArgumentNullException(nameof(principal));
        }

        var loggedInUserId = principal.FindFirstValue(ClaimTypes.Sid);

        if (typeof(T) == typeof(string))
        {
            return (T)Convert.ChangeType(loggedInUserId, typeof(T));
        }

        if (typeof(T) == typeof(int) || typeof(T) == typeof(long))
        {
            return loggedInUserId != null ? (T)Convert.ChangeType(loggedInUserId, typeof(T)) : (T)Convert.ChangeType(0, typeof(T));
        }

        throw new Exception("Invalid type provided");
    }
    
    public static T ObterColaboradorId<T>(this ClaimsPrincipal principal)
    {
        if (principal == null)
        {
            throw new ArgumentNullException(nameof(principal));
        }

        var colaboradorId = principal.FindFirstValue("ColaboradorId");

        if (typeof(T) == typeof(string))
        {
            return (T)Convert.ChangeType(colaboradorId, typeof(T));
        }

        if (typeof(T) == typeof(int) || typeof(T) == typeof(long))
        {
            return colaboradorId != null ? (T)Convert.ChangeType(colaboradorId, typeof(T)) : (T)Convert.ChangeType(0, typeof(T));
        }

        throw new Exception("Invalid type provided");
    }
    
    public static T ObterEmpresaId<T>(this ClaimsPrincipal principal)
    {
        if (principal == null)
        {
            throw new ArgumentNullException(nameof(principal));
        }

        var empresaId = principal.FindFirstValue("EmpresaId");

        if (typeof(T) == typeof(string))
        {
            return (T)Convert.ChangeType(empresaId, typeof(T));
        }

        if (typeof(T) == typeof(int) || typeof(T) == typeof(long))
        {
            return empresaId != null ? (T)Convert.ChangeType(empresaId, typeof(T)) : (T)Convert.ChangeType(0, typeof(T));
        }

        throw new Exception("Invalid type provided");
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