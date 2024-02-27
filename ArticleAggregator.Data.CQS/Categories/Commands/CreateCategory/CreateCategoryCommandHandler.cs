using ArticleAggregator.Data.CustomExceptions;
using ArticleAggregator.Mapping;
using MediatR;
using System.Reflection.Metadata.Ecma335;

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

        var isExist = _dbContext.Categories.FirstOrDefault(item => item.Name.Equals(request.CategoryDto.Name, StringComparison.OrdinalIgnoreCase));

        if (isExist == null)
        {
            return;
        }

        var category = _mapper.CategoryDtoToCategory(request.CategoryDto);
        await _dbContext.Categories.AddAsync(category, cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}