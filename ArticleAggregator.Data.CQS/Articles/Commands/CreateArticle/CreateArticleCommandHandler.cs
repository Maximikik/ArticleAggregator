using ArticleAggregator.Core.Dto;
using ArticleAggregator.Data.Entities;
using ArticleAggregator.Mapping;
using ArticleAggregator_Repositories;
using MediatR;

namespace ArticleAggregator.Data.CQS.Articles.Commands.CreateArticle;

public class CreateArticleCommandHandler(IUnitOfWork unitOfWork, IMapper articleMapper) : IRequestHandler<CreateArticleCommand>
{
    public async Task Handle(CreateArticleCommand request, CancellationToken cancellationToken)
    {
        var article = articleMapper.Map<ArticleDto, Article>(request.ArticleDto);
        article.Id = Guid.NewGuid();

        var categories = unitOfWork.CategoryRepository.FindBy(c => request.ArticleDto.CategoriesId.Contains(c.Id)).ToList();
        article.Categories = categories;

        await unitOfWork.ArticleRepository.InsertOne(article);
        await unitOfWork.ArticleRepository.SaveChangesAsync();
    }
}
