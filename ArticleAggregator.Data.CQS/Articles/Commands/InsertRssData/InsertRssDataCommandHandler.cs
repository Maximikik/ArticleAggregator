using ArticleAggregator.Core.Dto;
using ArticleAggregator.Data.Entities;
using ArticleAggregator.Mapping;
using ArticleAggregator_Repositories;
using MediatR;

namespace ArticleAggregator.Data.CQS.Articles.Commands.InsertRssData;

public class InsertRssDataCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<InsertRssDataCommand>
{
    public async Task Handle(InsertRssDataCommand request, CancellationToken cancellationToken)
    {
        var articles = request.Articles
            .Select(mapper.Map<ArticleDto, Article>)
            .ToArray();

        await unitOfWork.ArticleRepository.InsertMany(articles);
        await unitOfWork.ArticleRepository.SaveChangesAsync();
    }
}
