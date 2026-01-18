using ArticleAggregator_Repositories;
using MediatR;

namespace ArticleAggregator.Data.CQS.Articles.Commands.DeleteArticleById;

public class DeleteArticleByIdCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteArticleByIdCommand, Guid>
{
    public async Task<Guid> Handle(DeleteArticleByIdCommand request, CancellationToken cancellationToken)
    {
        await unitOfWork.ArticleRepository.DeleteById(request.ArticleId);

        return request.ArticleId;
    }
}
