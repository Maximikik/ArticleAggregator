using ArticleAggregator.Models;
using ArticleAggregator_Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArticleAggregator.Controllers;

public class ClientController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public ClientController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<IActionResult> ClientsPreview()
    {
        var clientsList = await _unitOfWork.ClientRepository
            .FindBy(categories => categories.FavouriteCategories != null,
                client => client.FavouriteCategories)
            .Select(client => new ClientModel()
            {
                Id = client.Id,
                Login = client.Login
            })
            .ToListAsync();
        return View(clientsList);
    }
}
