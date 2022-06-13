using Shops.Domain.Common;

namespace Shops.Domain.Entities
{
    public class Discount : BaseEntityDate
    {
        public string DiscountCode { get; set; }
        public string DiscountName { get; set; }
        public double Percentage { get; set; }
    }
}