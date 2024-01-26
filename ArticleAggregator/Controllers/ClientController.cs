//using ArticleAggregator.Data.Entities;
//using ArticleAggregator.Core.Models;
//using ArticleAggregator_Repositories;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;

//namespace ArticleAggregator.Controllers;

//public class ClientController : Controller
//{
//    private readonly IUnitOfWork _unitOfWork;

//    public ClientController(IUnitOfWork unitOfWork)
//    {
//        _unitOfWork = unitOfWork;
//    }

//    [HttpGet]
//    public async Task<IActionResult> ClientsPreview()
//    {
//        var clientsList = await _unitOfWork.ClientRepository
//            .FindBy(categories => categories.FavouriteCategories != null,
//                client => client.FavouriteCategories)
//            .Select(client => new ClientModel()
//            {
//                Id = client.Id,
//                Login = client.Login
//            })
//            .ToListAsync();
//        return View(clientsList);
//    }

//    [HttpGet]
//    public async Task<IActionResult> Create()
//    {
//        return View();
//    }

//    [HttpPost]
//    public async Task<IActionResult> Create([FromForm] ClientModel categoryModel)
//    {
//        var client = new Client
//        {
//            Id = categoryModel.Id,
//            Login = categoryModel.Login,
//            PasswordHash = categoryModel.Password,
//        };

//        await _unitOfWork.ClientRepository.InsertOne(client);
//        await _unitOfWork.Commit();

//        return RedirectToAction("ClientsPreview");
//    }

//    [HttpGet]
//    public async Task<IActionResult> Delete()
//    {
//        var clients = await _unitOfWork.ClientRepository.GetAll();

//        var model = new DeleteModel()
//        {
//            DeleteList = new List<SelectListItem>()
//        };

//        foreach (var item in clients)
//        {
//            model.DeleteList.Add(new SelectListItem { Text = item.Login, Value = item.Id.ToString() });
//        }

//        return View(model);
//    }

//    [HttpPost]
//    public async Task<IActionResult> Delete([FromForm] DeleteModel DeleteModel)
//    {
//        await _unitOfWork.ClientRepository.DeleteById(DeleteModel.Selected);
//        await _unitOfWork.Commit();

//        return RedirectToAction("ClientsPreview");
//    }
//}
