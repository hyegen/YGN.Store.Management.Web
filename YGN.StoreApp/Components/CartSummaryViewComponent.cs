using Microsoft.AspNetCore.Mvc;
using YGN.Services.Contracts.Manager;
using YGN.StoreApp.Entities.Models;

namespace YGN.StoreApp.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private readonly Cart _cart;

        public CartSummaryViewComponent(Cart cartService)
        {
            _cart = cartService;
        }
        public string Invoke()
        {
            return _cart.Lines.Count().ToString();
        }
    }
}
