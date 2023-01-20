namespace PontoCerto.WebApplication.Infrastructure.Security;

public interface IIdentityService
{
    Task<string> GetUserId(string userName);
    Task<string> GetUserName(string id);
    Task Register(string userName, string password, string role);
    Task SignIn(string userName, string password);
    Task SignOut();
}