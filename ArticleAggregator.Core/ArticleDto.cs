﻿namespace ArticleAggregator.Core;

public class ArticleDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string SourceUrl { get; set; } = null!;
    public double? Rating { get; set; }
    public Guid ArticleSourceId { get; set; }
}
