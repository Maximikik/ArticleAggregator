using ArticleAggregator.Core.Dto;
using ArticleAggregator.Data.CustomExceptions;
using ArticleAggregator.Data.Entities;
using ArticleAggregator.Mapping;
using MediatR;

namespace ArticleAggregator.Data.CQS.Comments.Commands.AddCommentToArticle;

public class AddCommentToArticleCommandHandler(ArticlesAggregatorDbContext _dbContext, IMapper _mapper) : IRequestHandler<AddCommentToArticleCommand>
{
    public async Task Handle(AddCommentToArticleCommand request, CancellationToken cancellationToken)
    {
        _ = request.CommentDto ?? throw new NotFoundException("Comment");

        var comment = _mapper.Map<CommentDto, Comment>(request.CommentDto);

        await _dbContext.Comments.AddAsync(comment, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
