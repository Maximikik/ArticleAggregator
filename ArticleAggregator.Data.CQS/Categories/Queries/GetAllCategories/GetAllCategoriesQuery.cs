using ArticleAggregator.Data.Entities;
using MediatR;

namespace ArticleAggregator.Data.CQS.Categories.Queries.GetAllCategories;

public class GetAllCategoriesQuery : IRequest<List<Category>>
{ }
