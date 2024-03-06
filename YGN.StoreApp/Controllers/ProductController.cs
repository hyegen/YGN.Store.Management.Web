using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YGN.StoreApp.Entities.Models;
using YGN.StoreApp.Repositories;


namespace YGN.StoreApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly RepositoryContext _context; //DI

        public ProductController(RepositoryContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model= _context.Products.ToList();
            return View(model);
        }
        public IActionResult Get(int id)
        {
            Product product = _context.Products.First(p=>p.ProductId.Equals(id));
            return View(product);
        }
    }
}
