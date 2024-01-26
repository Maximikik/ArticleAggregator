using ArticleAggregator.Data.Entities;
using MediatR;

namespace ArticleAggregator.Data.CQS.Roles.Queries.GetAllRoles;

public class GetAllRolesQuery : IRequest<List<Role>>
{ }
