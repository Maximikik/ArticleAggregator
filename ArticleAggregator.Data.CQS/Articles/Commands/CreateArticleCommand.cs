﻿using ArticleAggregator.Core.Dto;
using MediatR;

namespace ArticleAggregator.Data.CQS.Articles.Commands;

public class CreateArticleCommand : IRequest
{
    public ArticleDto ArticleDto { get; set; } = null!;
}
