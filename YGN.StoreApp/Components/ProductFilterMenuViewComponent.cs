using Microsoft.AspNetCore.Mvc;

namespace YGN.StoreApp.Components
{
    public class ProductFilterMenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
