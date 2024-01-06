using ArticleAggregator.Mapping;
using ArticleAggregator.Models;
using ArticleAggregator.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArticleAggregator.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SourceController : ControllerBase
{
    private readonly ISourceService _sourceController;
    private readonly SourceMapper _sourceMapper;

    public SourceController(ISourceService sourceService,
        SourceMapper sourceMapper)
    {
        _sourceController = sourceService;
        _sourceMapper = sourceMapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllSources()
    {
        var sources = await _sourceController.GetAllSources();
        return Ok(sources);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSourceById(Guid id)
    {
        var source = await _sourceController.GetSourceById(id);
        return Ok(source);
    }

    //[HttpGet]
    //public async Task<IActionResult> GetSourceByName(string name)
    //{
    //    var source = await _sourceController.GetSourceByName(name);
    //    return Ok(source);
    //}

    //[HttpGet("Articles/{id}")]
    //public async Task<IActionResult> GetArticlesOfSourceById(Guid id)
    //{
    //    var sources = await _sourceController.GetArticlesOfSourceById(id);
    //    return Ok(sources);
    //}

    //[HttpGet("Articles/{name}")]
    //public async Task<IActionResult> GetArticlesOfSourceByName(string name)
    //{
    //    var sources = await _sourceController.GetArticlesOfSourceByName(name);
    //    return Ok(sources);
    //}

    [HttpPost]
    public async Task<IActionResult> CreateSource([FromBody] SourceModel sourceModel)
    {
        var dto = _sourceMapper.SourceModelToSourceDto(sourceModel);

        await _sourceController.CreateSource(dto);

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategoryById(Guid id)
    {
        await _sourceController.DeleteSource(id);
        return Ok();
    }
}
