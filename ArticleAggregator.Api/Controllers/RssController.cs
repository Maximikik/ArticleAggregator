using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace ArticleAggregator.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class RssController : Controller
{
    private readonly RssReader _rssReader;

    public RssController(RssReader rssReader)
    {
        _rssReader = rssReader;
    }

    [HttpGet]
    //[Authorize(Roles ="User")]
    public async Task<IActionResult> GetRssFeed(string rssFeedUrl)
    {
        try
        {
            string rssXml = await _rssReader.GetRssFeedAsync(rssFeedUrl);

            if (rssXml != null)
            {
                //var rssItems = _rssReader.ParseRssFeed(rssXml);
                //return Ok(rssItems);
                return Ok(rssXml);
            }
            else
            {
                return NotFound();
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}

public class RssReader
{
    private readonly HttpClient _httpClient;

    public RssReader()
    {
        _httpClient = new HttpClient();
    }

    public async Task<string> GetRssFeedAsync(string rssFeedUrl)
    {
        HttpResponseMessage response = await _httpClient.GetAsync(rssFeedUrl);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsStringAsync();
        }

        return null;
    }

    public IEnumerable<string> ParseRssFeed(string rssXml)
    {
        XDocument xDoc = XDocument.Parse(rssXml);

        var items = xDoc.Descendants("item")
            .Select(item => item.Element("title")?.Value)
            .Where(title => !string.IsNullOrEmpty(title));

        return items;
    }
}
