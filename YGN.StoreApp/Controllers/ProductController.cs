using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YGN.StoreApp.Entities.Models;
using YGN.StoreApp.Repositories;
using YGN.StoreApp.Repositories.Contracts;


namespace YGN.StoreApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IRepositoryManager _repositoryManager;
        public ProductController(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public IActionResult Index()
        {
            var model = _repositoryManager.Product.GetAllProducts(false);
            return View(model);
        }
        public IActionResult Get(int id)
        {
            var model = _repositoryManager.Product.GetOneProduct(id, false);
            return View(model);
        }
    }
}
