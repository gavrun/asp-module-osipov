using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppCoreProduct.Models;
using WebAppCoreProduct.Services;

namespace WebAppCoreProduct.Pages
{
    public class ProductModel : PageModel
    {
        // inject service
        private readonly IDiscountService _discountService;

        // ctor
        public ProductModel(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        // model properties 
        public Product Product { get; set; }

        public string? MessageResult { get; private set; }


        // TEST https://localhost:7247/Index?name=Apple&price=77

        // TEST https://localhost:7247/Product ; Name = Laptop, Price = 1000, Discount = 10, Cashback = 5(default)


        // methods
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

            //var result = price * (decimal?)0.18;
            var result = _discountService.CalculateDiscount(price.Value, 18);

            MessageResult = $"For {name} product with price {price} discount is {result}";

            Product.Price = price;
            Product.Name = name;
        }

        public void OnPostDiscont(string name, decimal? price, double discont)
        {
            Product = new Product();

            if (price == null || price < 0 || string.IsNullOrEmpty(name) || discont < 0)
            {
                MessageResult = $"Warning: Incorrect data sent. Input again.";
                return;
            }

            //var result = price * (decimal?)discont / 100;
            var result = _discountService.CalculateDiscount(price.Value, discont);

            MessageResult = $"For {name} product with price {price} discount is {result}";

            Product.Price = price;
            Product.Name = name;
        }

        public void OnPostCash(string name, decimal? price, double discont, decimal cashback)
        {
            Product = new Product();

            if (price == null || price < 0 || string.IsNullOrEmpty(name) || discont < 0 || cashback < 0)
            {
                MessageResult = $"Warning: Incorrect data sent. Input again.";
                return;
            }

            //var result = price * (decimal?)discont / 100;
            //var resultCashback = price - cashback;

            // call service
            var result = _discountService.CalculateDiscount(price.Value, discont);
            var resultCashback = _discountService.ApplyCashback(price.Value, cashback);

            MessageResult = $"For {name} product with price {price} discount is {result}. New price using your cashback balance: {resultCashback}";

            Product.Price = price;
            Product.Name = name;
        }

    }
}
