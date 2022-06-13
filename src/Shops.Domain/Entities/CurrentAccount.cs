using Shops.Domain.Common;

namespace Shops.Domain.Entities
{
    public class CurrentAccount : BaseEntityDate
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAffiliate { get; set; }
        public Guid CurrentAccountTypeId { get; set; }
        public CurrentAccountType CurrentAccountType { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
    }
}