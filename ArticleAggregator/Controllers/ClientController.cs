using ArticleAggregator.Data.Entities;
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

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] ClientModel categoryModel)
    {
        var client = new Client
        {
            Id = categoryModel.Id,
            Login = categoryModel.Login,
            Password = categoryModel.Password,
        };

        await _unitOfWork.ClientRepository.InsertOne(client);
        await _unitOfWork.Commit();

        return RedirectToAction("ClientsPreview");
    }
}
