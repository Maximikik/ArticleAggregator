using ArticleAggregator.Core.Dto;
using ArticleAggregator.Core.Models;
using System.Security.Claims;

namespace ArticleAggregator.Services.Interfaces;

public interface IClientService
{
    public Task RegisterUser(ClientDto clientDto);
    Task<bool> IsUserExists(string email);
    Task<bool> IsAdmin(string email);
    public Task<ClaimsIdentity> Authenticate(string userName);
    public Task<bool> IsPasswordCorrect(string email, string password);

    public Task<ClientModel[]> GetAllClients();
    public Task<ClientModel[]> GetClientsByRole(string roleName);
    public Task<ClientModel> GetClientById(Guid id);
    public Task<ClientModel> GetClientByLogin(string login);
    Task<ClientModel> GetClientByRefreshToken(Guid refreshToken);

    public Task DeleteClient(Guid id);
}
