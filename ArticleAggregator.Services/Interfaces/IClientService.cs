using ArticleAggregator.Core;
using System.Security.Claims;

namespace ArticleAggregator.Services.Interfaces;

public interface IClientService
{
    public Task<int> RegisterUser(ClientDto clientDto);
    bool IsUserExists(string email);
    Task<bool> IsAdmin(string email);
    public Task<ClaimsIdentity> Authenticate(string userName);
    public Task<bool> IsPasswordCorrect(string email, string password);

    public Task<ClientDto[]?> GetAllClients();
    public Task<ClientDto?> GetClientById(Guid id);
    public Task<ClientDto?> GetClientByLogin(string login);

    public Task<Guid> CreateClient(ClientDto dto);
}
