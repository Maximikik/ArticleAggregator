using ArticleAggregator.Data.CustomExceptions;
using ArticleAggregator_Repositories;
using MediatR;

namespace ArticleAggregator.Data.CQS.Articles.Commands.SetArticleRate;

public class SetArticleRateCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<SetArticleRateCommand>
{
    public async Task Handle(SetArticleRateCommand request, CancellationToken cancellationToken)
    {
        var article = await unitOfWork.ArticleRepository.GetById(request.Id)
            ?? throw new NotFoundException("Article", request.Id);

        article.Rating = request.Rate;

        await unitOfWork.ArticleRepository.SaveChangesAsync();
    }
}