namespace Shops.Application.Dtos
{
    public class DiscountDto
    {
        public string DiscountCode { get; set; }
        public string DiscountName { get; set; }
        public double Percentage { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}