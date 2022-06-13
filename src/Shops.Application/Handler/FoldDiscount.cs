namespace Shops.Application.Handler
{
    public class FoldDiscount : DiscountHandler
    {
        public FoldDiscount(decimal amount, double percentage) : base(amount, percentage)
        {
        }

        public override decimal GetDiscountAmount()
        {
            var data = Math.Floor(_amount / 100) * (decimal)_percentage;
            return _amount - data;
        }
    }
}