﻿using ArticleAggregator.Core;
using System.Security.Claims;

namespace ArticleAggregator.Services.Interfaces;

public interface IClientService
{
    public Task RegisterUser(ClientDto clientDto);
    Task<bool> IsUserExists(string email);
    Task<bool> IsAdmin(string email);
    public Task<ClaimsIdentity> Authenticate(string userName);
    public Task<bool> IsPasswordCorrect(string email, string password);

    public Task<ClientDto[]?> GetAllClients();
    public Task<ClientDto?> GetClientByRole();
    public Task<ClientDto?> GetClientById(Guid id);
    public Task<ClientDto?> GetClientByLogin(string login);
    Task<ClientDto> GetClientByRefreshToken(Guid refreshToken);

    //public Task<Guid> CreateClient(ClientDto dto);
    public Task DeleteClient(Guid id);
}
