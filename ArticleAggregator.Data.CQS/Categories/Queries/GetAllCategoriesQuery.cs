﻿using ArticleAggregator.Data.Entities;
using MediatR;

namespace ArticleAggregator.Data.CQS.Categories.Queries;

public class GetAllCategoriesQuery : IRequest<List<Category>>
{ }
