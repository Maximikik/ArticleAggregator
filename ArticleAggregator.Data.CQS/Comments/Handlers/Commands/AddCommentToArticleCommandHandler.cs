using ArticleAggregator.Data.CQS.Comments.Commands;
using ArticleAggregator.Mapping;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArticleAggregator.Data.CQS.Comments.Handlers.Commands;

public class AddCommentToArticleCommandHandler : IRequestHandler<AddCommentToArticleCommand>
{
    private readonly ArticlesAggregatorDbContext _dbContext;
    private readonly CommentMapper _mapper;

    public AddCommentToArticleCommandHandler(ArticlesAggregatorDbContext dbContext,
        CommentMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task Handle(AddCommentToArticleCommand request, CancellationToken cancellationToken)
    {
        var comment = _mapper.CommentDtoToComment(request.CommentDto);

        await _dbContext.Comments.AddAsync(comment, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
