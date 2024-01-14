using Microsoft.AspNetCore.Mvc.Rendering;

namespace ArticleAggregator.Models;

public class DeleteModel
{
    public List<SelectListItem> DeleteList { get; set; }
    public Guid Selected { get; set; }
}
