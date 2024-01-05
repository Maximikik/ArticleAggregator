﻿using ArticleAggregator.Core;
using MediatR;

namespace ArticleAggregator.Data.CQS.Comments.Commands;

public class AddCommentToArticleCommand : IRequest
{
    public CommentDto Comment { get; set; } = null!;
}
