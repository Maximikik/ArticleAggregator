using ArticleAggregator.Core.Dto;
using ArticleAggregator.Data;
using ArticleAggregator.Data.CustomExceptions;
using ArticleAggregator.Data.Entities;
using ArticleAggregator_Repositories.Interfaces;
using Azure.AI.OpenAI;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ArticleAggregator_Repositories.Repositories;

public class Repository<T> : IRepository<T> where T : class, IBaseEntity
{
    private readonly ArticlesAggregatorDbContext _dbContext;
    protected readonly DbSet<T> _dbSet;
    public Repository(ArticlesAggregatorDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<T>();
    }

    public async Task<T?> GetById(Guid id,
        params Expression<Func<T, object>>[] includes)
    {
        var resultQuery = _dbSet.AsQueryable();
        if (includes.Any())
        {
            resultQuery = includes.Aggregate(resultQuery,
                (current, include)
                    => current.Include(include));
        }

        return await resultQuery.FirstOrDefaultAsync(entity => entity.Id.Equals(id));
    }

    public async Task<T?> GetByIdAsNoTracking(Guid id)
    {
        return await _dbSet.AsNoTracking()
            .FirstOrDefaultAsync(entity => entity.Id.Equals(id));
    }

    public IQueryable<T> FindBy(Expression<Func<T, bool>> wherePredicate,
        params Expression<Func<T, object>>[] includes)
    {
        var resultQuery = _dbSet.Where(wherePredicate);
        if (includes.Any())
        {
            resultQuery = includes.Aggregate(resultQuery,
                (current, include)
                    => current.Include(include));
        }

        return resultQuery;
    }

    public virtual IQueryable<T> GetAsQueryable()
    {
        return _dbSet.AsQueryable();
    }

    public virtual async Task InsertMany(IEnumerable<T> entities)
    {
        await _dbSet.AddRangeAsync(entities);
    }

    public async Task Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public async Task Patch(Guid id, List<PatchDto> patchDtos)
    {
        var entity = await GetById(id);
        if (entity != null)
        {
            var nameValuePairProperties = patchDtos
                .ToDictionary(
                    k => k.PropertyName,
                    v => v.PropertyValue);

            var dbEntityEntry = _dbContext.Entry(entity);

            dbEntityEntry.CurrentValues.SetValues(nameValuePairProperties);
            dbEntityEntry.State = EntityState.Modified;
        }
        else
        {
            throw new ArgumentException("Incorrect Id for update", nameof(id));
        }
    }

    public virtual async Task InsertOne(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public virtual async Task DeleteById(Guid id)
    {
        var entityToDelete = await GetById(id);
        if (entityToDelete != null)
        {
            _dbSet.Remove(entityToDelete);
        }
        else
        {
            throw new ArgumentException("Incorrect Id for delete", nameof(id));
        }
    }

    public virtual void DeleteMany(IEnumerable<T> entities)
    {
        if (entities.Any())
        {
            var entitiesForDelete = entities
                .Where(article => _dbSet.Any(dbe => dbe.Id.Equals(article.Id)))
                .ToList();
            _dbSet.RemoveRange(entitiesForDelete);
        }
    }

    public async Task<int> Count()
    {
        return await _dbSet.CountAsync();
    }

    public Task Patch(Guid id, IEnumerable<PatchDto> patchDtos)
    {
        throw new NotImplementedException();
    }

    public async Task<List<T>> GetAll()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<int> RateTextForPositivity(string text)
    {
        OpenAIClient client = new OpenAIClient("");

        var options = new ChatCompletionsOptions
        {
            Messages =
            {
                new ChatRequestUserMessage($"Rate the text on positivity on a scale of 0 to 9: \"{text}\"" +
                "\nAnswer please like this: \"{number}\"")
            },
            DeploymentName = "gpt-3.5-turbo"
        };

        var openAiResponse = await client.GetChatCompletionsAsync(options);

        int rate;

        if (!Int32.TryParse(openAiResponse.Value.Choices[0].Message.Content, out rate))
        {
            throw new IncorrectResponseFromChatGpt(openAiResponse.Value.Choices[0].Message.Content, "Rate");
        }

        return rate;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }
}
