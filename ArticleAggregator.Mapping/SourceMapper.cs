﻿using ArticleAggregator.Core.Dto;
using ArticleAggregator.Core.Models;
using ArticleAggregator.Data.Entities;
using Riok.Mapperly.Abstractions;

namespace ArticleAggregator.Mapping;

[Mapper]
public partial class SourceMapper
{
    public partial SourceDto SourceToSourceDto(Source source);
    public partial Source SourceDtoToSource(SourceDto sourceDto);
    public partial SourceModel SourceDtoToSourceModel(SourceDto sourceDto);
    public partial SourceDto SourceModelToSourceDto(SourceModel sourceModel);
}
