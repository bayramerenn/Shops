namespace Shops.Application.Handler
{
    public class EmployeeDiscountHandler : DiscountHandler
    {
        public EmployeeDiscountHandler(decimal amount, double percentage) : base(amount, percentage)
        {
        }

        public override decimal GetDiscountAmount()
        {
            return _amount - ((_amount * (decimal)_percentage) / 100);
        }
    }
}