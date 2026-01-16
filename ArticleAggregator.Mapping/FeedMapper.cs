using ArticleAggregator.Core.Dto;
using ArticleAggregator.Data.Entities;
using Riok.Mapperly.Abstractions;

namespace ArticleAggregator.Mapping;

[Mapper]
public partial class FeedMapper
{
    public partial FeedDto EntityToDto(Feed source);
    public partial Feed DtoToEntity(FeedDto source);
}
