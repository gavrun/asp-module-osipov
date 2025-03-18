namespace WebAppCoreProduct.Services
{
    public class DiscountService : IDiscountService
    {
        public decimal CalculateDiscount(decimal price, double discountPercentage)
        {
            return price * (decimal)(discountPercentage / 100);
        }

        public decimal ApplyCashback(decimal price, decimal cashback)
        {
            return price - cashback;
        }
    }
}
