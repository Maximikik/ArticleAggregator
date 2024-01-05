using ArticleAggregator.Data.CQS.Articles.Commands;
using ArticleAggregator.Data.CQS.Categories.Commands;
using ArticleAggregator.Mapping;
using MediatR;

namespace ArticleAggregator.Data.CQS.Categories.Handlers.Commands;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand>
{    
    private readonly ArticlesAggregatorDbContext _dbContext;
    private readonly CategoryMapper _mapper;

    public CreateCategoryCommandHandler(ArticlesAggregatorDbContext dbContext,
        CategoryMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = _mapper.CategoryDtoToCategory(request.CategoryDto);
        await _dbContext.Categories.AddAsync(category, cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}