using ArticleAggregator.Core;
using ArticleAggregator.Data.Entities;
using ArticleAggregator.Models;
using Riok.Mapperly.Abstractions;

namespace ArticleAggregator.Mapping;

[Mapper]
public partial class SourceMapper
{
    public partial SourceDto ClientToClientDto(Source source);
    public partial Source ClientDtoToClient(SourceDto sourceDto);
    public partial SourceModel ClientDtoToClientModel(SourceDto sourceDto);
    public partial SourceDto ClientModelToClientDto(SourceModel sourceModel);
}
