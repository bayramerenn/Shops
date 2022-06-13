using Shops.Domain.Common;

namespace Shops.Domain.Entities
{
    public class Invoice : BaseEntityDate
    {
        public decimal Amount { get; set; }
        public bool IsGrocery { get; set; }
        public Guid CurrentAccountId { get; set; }
        public CurrentAccount CurrentAccount { get; set; }
    }
}