using ArticleAggregator.Core.Dto;
using ArticleAggregator.Data.CustomExceptions;
using ArticleAggregator.Data.Entities;
using ArticleAggregator.Mapping;
using MediatR;

namespace ArticleAggregator.Data.CQS.Categories.Commands.CreateCategory;

public class CreateCategoryCommandHandler(ArticlesAggregatorDbContext _dbContext, IMapper _mapper) : IRequestHandler<CreateCategoryCommand>
{
    public async Task Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        _ = request.CategoryDto ?? throw new NotFoundException("Category");

        var isExist = _dbContext.Categories.FirstOrDefault(item => item.Name.Equals(request.CategoryDto.Name, StringComparison.OrdinalIgnoreCase));

        if (isExist == null)
        {
            return;
        }

        var category = _mapper.Map<CategoryDto, Category>(request.CategoryDto);
        await _dbContext.Categories.AddAsync(category, cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}