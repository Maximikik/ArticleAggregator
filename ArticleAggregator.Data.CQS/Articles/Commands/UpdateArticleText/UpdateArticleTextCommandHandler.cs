﻿using ArticleAggregator.Data.CustomExceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArticleAggregator.Data.CQS.Articles.Commands.UpdateArticleText;

public class UpdateArticleTextCommandHandler : IRequestHandler<UpdateArticleTextCommand>
{
    private readonly ArticlesAggregatorDbContext _dbContext;

    public UpdateArticleTextCommandHandler(ArticlesAggregatorDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(UpdateArticleTextCommand request, CancellationToken cancellationToken)
    {
        var articles = await _dbContext.Articles.Where(article => request.ArticlesData.Keys
             .Contains(article.Id))
             .ToListAsync(cancellationToken)
             ?? throw new NotFoundException("Articles");

        foreach (var article in articles)
        {
            article.Title = request.ArticlesData[article.Id];
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
