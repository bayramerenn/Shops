namespace Shops.Application.Handler
{
    public class NotDiscountHandler : DiscountHandler
    {
        public NotDiscountHandler(decimal amount, double percentage = 0) : base(amount, percentage)
        {
        }
    }
}