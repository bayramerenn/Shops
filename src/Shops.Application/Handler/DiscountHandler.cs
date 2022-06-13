namespace Shops.Application.Handler
{
    public abstract class DiscountHandler
    {
        public readonly decimal _amount;
        public readonly double _percentage;

        protected DiscountHandler(decimal amount, double percentage = 0)
        {
            _amount = amount;
            _percentage = percentage;
        }

        public virtual decimal GetDiscountAmount() => _amount;
    }
}