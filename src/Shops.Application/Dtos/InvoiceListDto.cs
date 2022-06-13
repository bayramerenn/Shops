namespace Shops.Application.Dtos
{
    public class InvoiceListDto
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public bool IsGrocery { get; set; }
        public Guid CurrentAccountId { get; set; }
        public string FullName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}