using ArticleAggregator.Data.Entities;

namespace ArticleAggregator_Repositories.Interfaces;

public interface IClientRepository: IRepository<Client>
{
    Task<Client> GetByName(string name);
    Task<Client> GetBySurname(string surname);
}
