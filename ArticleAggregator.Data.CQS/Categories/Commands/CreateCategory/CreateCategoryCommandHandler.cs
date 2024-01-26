using ArticleAggregator.Data.CustomExceptions;
using ArticleAggregator.Mapping;
using MediatR;

namespace ArticleAggregator.Data.CQS.Categories.Commands.CreateCategory;

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
        _ = request.CategoryDto ?? throw new NotFoundException("Category");

        var category = _mapper.CategoryDtoToCategory(request.CategoryDto);
        await _dbContext.Categories.AddAsync(category, cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}