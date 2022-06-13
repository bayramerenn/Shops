namespace Shops.Application.Handler
{
    public class OldCustomerDiscountHandler : DiscountHandler
    {
        public OldCustomerDiscountHandler(decimal amount, double percentage) : base(amount, percentage)
        {
        }

        public override decimal GetDiscountAmount()
        {
            return _amount - ((_amount * (decimal)_percentage) / 100);
        }
    }
}