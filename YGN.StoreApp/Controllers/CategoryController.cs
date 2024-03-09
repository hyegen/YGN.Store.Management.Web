using Microsoft.AspNetCore.Mvc;
using YGN.StoreApp.Entities.Models;
using YGN.StoreApp.Repositories.Contracts;

namespace YGN.StoreApp.Controllers
{
    public class CategoryController : Controller
    {
        private IRepositoryManager _repositoryManager;
        public CategoryController(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public IActionResult Index()
        {
            var result = _repositoryManager.Category.FindAll(false);
            return View(result);
        }
    }
}
