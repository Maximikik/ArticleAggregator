using ArticleAggregator.Data.Entities;

namespace ArticleAggregator_Repositories.Interfaces;

public interface IClientRepository : IRepository<Client>
{
    Task<Client> GetByLogin(string name);
}
