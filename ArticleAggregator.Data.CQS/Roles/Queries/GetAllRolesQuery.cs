using ArticleAggregator.Data.Entities;
using MediatR;

namespace ArticleAggregator.Data.CQS.Roles.Queries;

public class GetAllRolesQuery : IRequest<List<Role>>
{ }
