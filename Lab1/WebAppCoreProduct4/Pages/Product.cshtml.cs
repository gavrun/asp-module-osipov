using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppCoreProduct.Models;

namespace WebAppCoreProduct.Pages
{
    public class ProductModel : PageModel
    {
        public Product Product { get; set; }

        public string? MessageResult { get; private set; }


        // TEST https://localhost:7247/Index?name=Apple&price=77

        // TEST https://localhost:7247/Product

        public void OnGet(string name, decimal? price)
        {
            MessageResult = $"Info: Products discount available.";
        }

        public void OnPost(string name, decimal? price)
        {
            Product = new Product();

            if (price == null || price < 0 || string.IsNullOrEmpty(name))
            {
                MessageResult = $"Warning: Incorrect data sent. Input again.";
                return;
            }

            var result = price * (decimal?)0.18;
            MessageResult = $"For {name} product with price {price} discount is {result}";

            Product.Price = price;
            Product.Name = name;
        }
    }
}
