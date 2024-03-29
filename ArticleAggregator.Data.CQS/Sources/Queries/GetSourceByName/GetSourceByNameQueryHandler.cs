﻿using ArticleAggregator.Data.CustomExceptions;
using ArticleAggregator.Data.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArticleAggregator.Data.CQS.Sources.Queries.GetSourceByName;

internal class GetSourceByNameQueryHandler : IRequestHandler<GetSourceByNameQuery, Source>
{
    private readonly ArticlesAggregatorDbContext _dbContext;

    public GetSourceByNameQueryHandler(ArticlesAggregatorDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Source> Handle(GetSourceByNameQuery request, CancellationToken cancellationToken)
    {
        return await _dbContext.Sources.FirstOrDefaultAsync(source => source.Name.Equals(request.Name), cancellationToken)
            ?? throw new NotFoundException("Source", request.Name);
    }
}
