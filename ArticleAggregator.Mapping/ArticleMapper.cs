using ArticleAggregator.Core.Dto;
using ArticleAggregator.Data.Entities;
using ArticleAggregator.Models;
using Riok.Mapperly.Abstractions;

namespace ArticleAggregator.Mapping;

[Mapper]
public partial class ArticleMapper
{
    public partial ArticleDto ArticleToArticleDto(Article article);
    public partial Article ArticleDtoToArticle(ArticleDto article);
    public partial ArticleModel ArticleDtoToArticleModel(ArticleDto article);
    public partial ArticleDto ArticleModelToArticleDto(ArticleModel article);
}
