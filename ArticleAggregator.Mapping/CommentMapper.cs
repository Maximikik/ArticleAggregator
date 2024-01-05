using ArticleAggregator.Core;
using ArticleAggregator.Data.Entities;
using ArticleAggregator.Models;
using Riok.Mapperly.Abstractions;

namespace ArticleAggregator.Mapping;

[Mapper]
public partial class CommentMapper
{
    public partial CommentDto CommentToCommentDto(Comment comment);
    public partial Comment CommentDtoToComment(CommentDto commentDto);
    public partial CommentModel CommentDtoToCommentModel(CommentDto commentDto);
    public partial CommentDto CommentModelToCommentDto(CommentModel commentModel);
}
