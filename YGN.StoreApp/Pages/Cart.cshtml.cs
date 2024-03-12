using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YGN.Services.Contracts.Manager;
using YGN.StoreApp.Entities.Models;

namespace YGN.StoreApp.Pages
{
    public class CartModel : PageModel
    {
        private readonly IServiceManager _manager;
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; } = "/";
        public CartModel(IServiceManager manager, Cart cart)
        {
            _manager = manager;
            Cart = cart;
        }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(int productId, string returnUrl)
        {
            Product? product = _manager
                .ProductService
                .GetOneProduct(productId, false);

            if (product is not null)
            {
                Cart.AddItem(product, 1);
            }
            return Page(); //returnUrl
        }

        //asp-page-handler will be use
        public IActionResult OnPostRemove(int id, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(x => x.Product.ProductId.Equals(id)).Product);
            return Page();
        }
    }
}
