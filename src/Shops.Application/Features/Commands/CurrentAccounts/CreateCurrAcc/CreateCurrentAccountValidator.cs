using FluentValidation;

namespace Shops.Application.Features.Commands.CurrentAccounts.CreateCurrAcc
{
    public class CreateCurrentAccountValidator:AbstractValidator<CreateCurrAccRequest>
    {
        public CreateCurrentAccountValidator()
        {
            RuleFor(c => c.FirstName)
                .NotNull()
                    .WithMessage("Lütfen kullanıcı adını boş geçmeyiniz.")
                .MaximumLength(50)
                .MinimumLength(2)
                    .WithMessage("Lütfen kullanıcı adını 5 ile 50 karakter arasında giriniz.");

            RuleFor(c => c.LastName)
                .NotNull()
                    .WithMessage("Lütfen kullanıcı adını adını boş geçmeyiniz.")
                .MaximumLength(50)
                .MinimumLength(2)
                    .WithMessage("Lütfen kullanıcı soy adını adını 5 ile 50 karakter arasında giriniz.");

            RuleFor(c => c.CurrentAccountTypeId)
                .NotEmpty()
                    .WithMessage("Lütfen type id alanını boş geçmeyiniz.");
               
        }
    }
}