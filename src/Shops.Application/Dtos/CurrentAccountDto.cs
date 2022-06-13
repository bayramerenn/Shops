namespace Shops.Application.Dtos
{
    public class CurrentAccountDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAffiliate { get; set; }
        public Guid CurrentAccountTypeId { get; set; }
        public string CurrAccDesc { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}