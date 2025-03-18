using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAppCoreProduct.Pages
{
    public class IndexModel : PageModel
    {
        // namespace WebAppCoreProduct.Pages ??
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public bool IsCorrect { get; set; } = true;

        // TEST https://localhost:<port>/Index?name=Tomato&price=31
        // https://localhost:7247/Index?name=Tomato&price=31

        public void OnGet(string name, decimal? price)
        {
            if (price == null || price < 0 || string.IsNullOrEmpty(name))
            {
                IsCorrect = false;
                return;
            }

            Price = price;
            Name = name;
        }
    }
}
