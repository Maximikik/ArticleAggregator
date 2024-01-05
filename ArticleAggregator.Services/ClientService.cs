using ArticleAggregator.Core;
using ArticleAggregator.Services.Interfaces;
using System.Security.Claims;

namespace ArticleAggregator.Services;

public class ClientService : IClientsService
{
    public Task<ClaimsIdentity> Authenticate(string userName)
    {
        throw new NotImplementedException();
    }

    public Task<Guid> CreateClient(ClientDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<ClientDto[]?> GetAllClients()
    {
        throw new NotImplementedException();
    }

    public Task<ClientDto?> GetClientById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<ClientDto?> GetClientByLogin(string login)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsAdmin(string email)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsPasswordCorrect(string email, string password)
    {
        throw new NotImplementedException();
    }

    public bool IsUserExists(string email)
    {
        throw new NotImplementedException();
    }

    public Task<int> RegisterUser(ClientDto clientDto)
    {
        throw new NotImplementedException();
    }
}
