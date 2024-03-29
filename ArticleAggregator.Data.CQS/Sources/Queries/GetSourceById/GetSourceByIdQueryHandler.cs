﻿using ArticleAggregator.Data.CustomExceptions;
using ArticleAggregator.Data.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArticleAggregator.Data.CQS.Sources.Queries.GetSourceById;

public class GetSourceByIdQueryHandler : IRequestHandler<GetSourceByIdQuery, Source>
{
    private readonly ArticlesAggregatorDbContext _dbContext;

    public GetSourceByIdQueryHandler(ArticlesAggregatorDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Source> Handle(GetSourceByIdQuery request, CancellationToken cancellationToken)
    {
        return await _dbContext.Sources.FirstOrDefaultAsync(source => source.Id.Equals(request.Id), cancellationToken)
            ?? throw new NotFoundException("Source", request.Id);
    }
}
