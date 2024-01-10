using ArticleAggregator.Core;

namespace ArticleAggregator.Services.Interfaces;

public interface ITokenService
{
    public Task<string> GenerateJwtToken(ClientDto clientDto);
    public Task<Guid> AddRefreshToken(string requestEmail, string ipAddress);
    Task<bool> CheckRefreshToken(Guid requestRefreshToken);
    Task RemoveRefreshToken(Guid requestRefreshToken);
}
