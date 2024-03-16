using Microsoft.AspNetCore.Mvc;
using YGN.Services.Contracts.Manager;

namespace YGN.StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IServiceManager _manager;

        public OrderController(IServiceManager manager)
        {
            _manager = manager;
        }
        public ActionResult Index()
        {
            var orders = _manager.OrderService.Orders;
            return View(orders);
        }
        [HttpPost]
        public ActionResult Complete([FromForm] int id)
        {
            _manager.OrderService.Complete(id);
            return RedirectToAction("Index");
        }
    }
}
