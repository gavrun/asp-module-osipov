namespace WebAppCoreProduct.Services
{
    public interface IDiscountService
    {
        // calculate discount based on price and discount percentage
        decimal CalculateDiscount(decimal price, double discountPercentage);

        // apply cashback based on price and cashback balance hardcoded
        decimal ApplyCashback(decimal price, decimal cashback);
    }
}
