using ArticleAggregator.Data.CustomExceptions;
using ArticleAggregator.Data.Entities;
using ArticleAggregator_Repositories;
using MediatR;

namespace ArticleAggregator.Data.CQS.Articles.Commands.CreateArticleWithSource;

public class CreateArticleWithSourceCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateArticleWithSourceCommand>
{

    public async Task Handle(CreateArticleWithSourceCommand request, CancellationToken cancellationToken)
    {
        _ = await unitOfWork.SourceRepository.GetById(request.ArticleSourceId)
            ?? throw new NotFoundException("Source", request.ArticleSourceId);

        var article = new Article
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Rating = request.Rating,
            ArticleSourceId = request.ArticleSourceId
        };

        await unitOfWork.ArticleRepository.InsertOne(article);
        await unitOfWork.ArticleRepository.SaveChangesAsync();
    }
}
