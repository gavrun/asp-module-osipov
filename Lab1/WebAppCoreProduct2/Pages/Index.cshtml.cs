using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppCoreProduct.Models;

namespace WebAppCoreProduct.Pages
{
    public class IndexModel : PageModel
    {
        // namespace WebAppCoreProduct.Pages ??

        public Product Product { get; set; }
        public bool IsCorrect { get; set; } = true;

        // TEST https://localhost:<port>/Index?name=Tomato&price=31
        // TEST https://localhost:7247/Index?name=Tomato&price=31
        // TEST https://localhost:7247/Index?name=Apple&price=77

        public void OnGet(string name, decimal? price)
        {
            Product = new Product();

            if (price == null || price < 0 || string.IsNullOrEmpty(name))
            {
                IsCorrect = false;
                return;
            }

            Product.Price = price;
            Product.Name = name;
        }
    }
}
