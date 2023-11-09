using ArticleAggregator.Data.Entities;
using ArticleAggregator.Models;
using ArticleAggregator_Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArticleAggregator.Controllers
{
    public class SourceController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SourceController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> SourcesPreview()
        {
            var articlesList = await _unitOfWork.SourceRepository
                .FindBy(source => !string.IsNullOrEmpty(source.Name),
                    article => article.Categories)
                .Select(source => new SourceModel()
                {
                    Id = source.Id,
                    Url = source.Url,
                    Name = source.Name
                })
                .ToListAsync();
            return View(articlesList);
        }

        [HttpGet]
        public async Task<IActionResult> Create(Guid id)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] SourceModel articleModel)
        {
            var source = new Source
            {
                Id = articleModel.Id,
                Name = articleModel.Name,
                Url = articleModel.Url
            };

            await _unitOfWork.SourceRepository.InsertOne(source);
            await _unitOfWork.Commit();

            return RedirectToAction("SourcesPreview");
        }
    }
}
