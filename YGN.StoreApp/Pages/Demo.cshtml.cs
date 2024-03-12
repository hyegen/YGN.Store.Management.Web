using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace YGN.StoreApp.Pages
{
    public class DemoModel : PageModel
    {
        public string? FullName => HttpContext?.Session?.GetString("name") ?? "";   //FullName is readonly

        public void OnGet()
        {

        }

        public void OnPost([FromForm] string name)
        {
            // FullName = name;
            HttpContext.Session.SetString("name", name);
        }
    }
}
