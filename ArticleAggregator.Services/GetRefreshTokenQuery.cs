using ArticleAggregator.Data.Entities;
using MediatR;

namespace ArticleAggregator.Services
{
    internal class GetRefreshTokenQuery : IRequest<RefreshToken>
    {
        public Guid Id { get; set; }
    }
}