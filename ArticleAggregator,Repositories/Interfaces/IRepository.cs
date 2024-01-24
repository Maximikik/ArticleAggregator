using ArticleAggregator.Core.Dto;
using ArticleAggregator.Data.Entities;
using System.Linq.Expressions;

namespace ArticleAggregator_Repositories.Interfaces;

public interface IRepository<T> where T : class, IBaseEntity
{
    Task<T?> GetById(Guid id, params Expression<Func<T, object>>[] includes);
    Task<T?> GetByIdAsNoTracking(Guid id);

    IQueryable<T> FindBy(Expression<Func<T, bool>> wherePredicate,
        params Expression<Func<T, object>>[] includes);
    IQueryable<T> GetAsQueryable();
    Task<List<T>> GetAll();

    Task InsertOne(T entity);
    Task InsertMany(IEnumerable<T> entities);

    Task Update(T entity);

    Task Patch(Guid id, IEnumerable<PatchDto> patchDtos);

    Task DeleteById(Guid id);
    void DeleteMany(IEnumerable<T> entities);

    Task<int> RateTextForPositivity(string article);

    Task<int> Count();
}
