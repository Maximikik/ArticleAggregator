using ArticleAggregator.Data.CustomExceptions;
using ArticleAggregator_Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArticleAggregator.Data.CQS.Articles.Commands.UpdateArticleText;

public class UpdateArticleTextCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateArticleTextCommand>
{
    public async Task Handle(UpdateArticleTextCommand request, CancellationToken cancellationToken)
    {
        var articles = await unitOfWork.ArticleRepository.FindBy(article => request.ArticlesData.Keys
             .Contains(article.Id))
             .ToListAsync(cancellationToken)
             ?? throw new NotFoundException("Articles");

        foreach (var article in articles)
        {
            article.Title = request.ArticlesData[article.Id];
        }

        await unitOfWork.ArticleRepository.SaveChangesAsync();
    }
}
