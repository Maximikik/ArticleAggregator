using ArticleAggregator.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ArticleAggregator.Models;

public class UpdateModel
{
    public List<SelectListItem> UpdateList { get; set; }
    public Guid Selected { get; set; }
    public Article SelectedArticle { get; set; }
}
