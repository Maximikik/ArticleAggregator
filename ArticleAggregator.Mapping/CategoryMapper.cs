﻿using ArticleAggregator.Core.Dto;
using ArticleAggregator.Core.Models;
using ArticleAggregator.Data.Entities;
using Riok.Mapperly.Abstractions;

namespace ArticleAggregator.Mapping;

[Mapper]
public partial class CategoryMapper
{
    public partial CategoryDto CategoryToCategoryDto(Category category);
    public partial Category CategoryDtoToCategory(CategoryDto categoryDto);
    public partial CategoryModel CategoryDtoToCategoryModel(CategoryDto categoryDto);
    public partial CategoryDto CategoryModelToCategoryDto(CategoryModel categoryModel);
}
