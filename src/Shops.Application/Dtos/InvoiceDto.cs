namespace Shops.Application.Dtos
{
    public class InvoiceDto
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public bool IsGrocery { get; set; }
        public Guid CurrentAccountId { get; set; }
        public string FullName { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal NetAmount { get; set; }
        public string CurrentAccountTypeDesc { get; set; }
        public string[] DiscountsApplied { get; set; }
    }
}