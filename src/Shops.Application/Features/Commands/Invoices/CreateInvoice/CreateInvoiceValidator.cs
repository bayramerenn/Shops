using FluentValidation;

namespace Shops.Application.Features.Commands.Invoices.CreateInvoice
{
    public class CreateInvoiceValidator : AbstractValidator<CreateInvoiceRequest>
    {
        public CreateInvoiceValidator()
        {
            RuleFor(c => c.Amount)
               .NotNull()
                   .WithMessage("Lütfen tutar alanını boş geçmeyiniz.");
          
            RuleFor(c => c.CurrentAccountId)
                .Empty()
                    .WithMessage("Lütfen kullanıcı id alanını boş geçmeyiniz.");
        }
    }
}