using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YGN.Services.Contracts.Manager;
using YGN.StoreApp.Entities.Models;
using YGN.StoreApp.Repositories;
using YGN.StoreApp.Repositories.Contracts;


namespace YGN.StoreApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public ProductController(IServiceManager repositoryManager)
        {
            _serviceManager = repositoryManager;
        }

        public IActionResult Index()
        {
            var model = _serviceManager.ProductService.GetAllProducts(false);
            return View(model);
        }
        public IActionResult Get([FromRoute(Name = "id")] int id)
        {
            var model = _serviceManager.ProductService.GetOneProduct(id, false);
            return View(model);
        }
    }
}
