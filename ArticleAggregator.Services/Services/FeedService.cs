using ArticleAggregator.Core.Dto;
using ArticleAggregator.Data.Entities;
using ArticleAggregator.Mapping;
using ArticleAggregator_Repositories;
using FeedAggregator.Services.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace ArticleAggregator.Services.Services;

public class FeedService(
    IUnitOfWork _unitOfWork,
    IMapper _mapper,
    IMediator _mediator,
    IConfiguration _configuration) : IFeedService
{
    public async Task<FeedDto> AddArticleToFeed(Guid articleId, Guid feedId)
    {
        var feed = await _unitOfWork.FeedRepository.AddArticleToFeed(articleId, feedId);
        await _unitOfWork.Commit();

        return _mapper.Map<Feed, FeedDto>(feed);
    }

    public async Task CreateFeed(FeedDto dto)
    {
        await _unitOfWork.FeedRepository.InsertOne(_mapper.Map<FeedDto, Feed>(dto));
        await _unitOfWork.Commit();
    }

    public async Task DeleteFeed(Guid id)
    {
        await _unitOfWork.FeedRepository.DeleteById(id);
        await _unitOfWork.Commit();
    }

    public async Task<IEnumerable<FeedDto>> GetAll()
    {
        var feeds = await _unitOfWork.FeedRepository.GetAll();

        return feeds.Select(_mapper.Map<Feed, FeedDto>);
    }

    public async Task<FeedDto?> GetFeedById(Guid id)
    {
        var feed = await _unitOfWork.FeedRepository.GetFeedWithArticles(id)
            ?? throw new Exception("feed is not found");

        return _mapper.Map<Feed, FeedDto>(feed);
    }

    public Task<FeedDto?> GetFeedByTitle(string name)
    {
        throw new NotImplementedException();
    }

    public Task InsertFeedsFromRssByFeedSourceId(Guid sourceId)
    {
        throw new NotImplementedException();
    }

    public async Task<FeedDto> RemoveArticleFromFeed(Guid articleId, Guid feedId)
    {
        var feed = await _unitOfWork.FeedRepository.RemoveArticleFromFeed(articleId, feedId);
        await _unitOfWork.Commit();

        return _mapper.Map<Feed, FeedDto>(feed);
    }
}
