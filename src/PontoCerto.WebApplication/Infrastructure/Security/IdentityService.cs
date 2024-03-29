using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using PontoCerto.Domain.Entities;
using PontoCerto.Domain.Notifications;
using PontoCerto.Domain.Repositories;
using PontoCerto.WebApplication.Infrastructure.Extensions;
using Claim = System.Security.Claims.Claim;

namespace PontoCerto.WebApplication.Infrastructure.Security;

public class IdentityService : IIdentityService
{
    private readonly IColaboradorRepository _colaboradorRepository;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly INotificator _notificator;
    private readonly ILogger<IdentityService> _logger;

    public IdentityService(
        IColaboradorRepository colaboradorRepository, 
        UserManager<IdentityUser> userManager, 
        SignInManager<IdentityUser> signInManager, 
        INotificator notificator, 
        ILogger<IdentityService> logger)
    {
        _colaboradorRepository = colaboradorRepository;
        _userManager = userManager;
        _signInManager = signInManager;
        _notificator = notificator;
        _logger = logger;
    }

    public async Task<string> GetUserId(string userName)
    {
        if (string.IsNullOrWhiteSpace(userName))
        {
            return string.Empty;
        }
        
        var user = await _userManager.FindByNameAsync(userName);

        return user == null ? string.Empty : user.Id;
    }

    public async Task<string> GetUserName(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            return string.Empty;
        }

        var user = await _userManager.FindByIdAsync(id);

        if (user == null || string.IsNullOrWhiteSpace(user.UserName))
        {
            return string.Empty;
        }
        
        return user.UserName;
    }

    public async Task Register(string userName, string password, string role)
    {
        //todo: criar teste
        if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
        {
            _notificator.Add(new Notification("UserName", "Login inválido"));
            _notificator.Add(new Notification("Password", "Senha inválida"));
            return;
        }

        if (string.IsNullOrWhiteSpace(role))
        {
            throw new Exception("não enviou role");
        }
        
        var identityUser = new IdentityUser(userName);
        
        var createResult = await _userManager.CreateAsync(identityUser, password);

        if (!createResult.Succeeded)
        {
            var mensagens = string.Join("\n", createResult.Errors.Select(x => $"{x.Code} - {x.Description}")); 
            _logger.LogError("identity lib: {mensagens}", mensagens);
            _notificator.Add(new Notification("UserName", "Falha ao cadastrar usuário"));
            return;
        }

        var addToRoleResult = await _userManager.AddToRoleAsync(identityUser, role);

        if (!addToRoleResult.Succeeded)
        {
            var mensagens = string.Join("\n", addToRoleResult.Errors.Select(x => $"{x.Code} - {x.Description}")); 
            _logger.LogError("identity lib: {mensagens}", mensagens);
            _notificator.Add(new Notification("UserName", "Falha ao adicionar permissões do usuário"));
        }
    }

    public async Task Register(Usuario usuario)
    {
        await Register(usuario.UserName, usuario.RawPassword, usuario.Role);
    }
    
    public async Task SignIn(string userName, string password)
    {
        var user = await _userManager.FindByNameAsync(userName);

        if (user == null)
        {
            return;
        }

        var claims = new List<Claim>
        {
            new(ClaimTypes.Sid, user.Id)
        };
        
        var colaborador = await _colaboradorRepository.FirstAsync(x => x.UsuarioId == user.Id.ToGuid(), default);

        if (colaborador != null)
        {
            claims.Add(new Claim("ColaboradorId", colaborador.Id.ToString()));    
        }

        var addClaimResult = await _userManager.AddClaimsAsync(user, claims);

        if (!addClaimResult.Succeeded)
        {
            var mensagens = string.Join("\n", addClaimResult.Errors.Select(x => $"{x.Code} - {x.Description}")); 
            _logger.LogError("identity lib: {mensagens}", mensagens);
            _notificator.Add(new Notification("UserName", "Falha ao autenticar usuario"));
        }

        var passwordSignInResult = await _signInManager.PasswordSignInAsync(userName, password, false, false);

        if (!passwordSignInResult.Succeeded)
        { 
            _notificator.Add(new Notification("UserName", "login ou senha inválidos"));
        }
    }
    
    public async Task SignOut()
    {
        await _signInManager.SignOutAsync();
    }
}