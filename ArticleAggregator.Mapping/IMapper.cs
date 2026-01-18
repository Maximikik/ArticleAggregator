namespace ArticleAggregator.Mapping;

public interface IMapper
{
    abstract TTarget Map<TSource, TTarget>(TSource source);
}
