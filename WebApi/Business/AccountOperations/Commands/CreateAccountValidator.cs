using FluentValidation;
using WebApi.Models;

namespace WebApi.Business.AccountOperations.Commands
{
    public class CreateAccountValidator : AbstractValidator<AccountModelRequest>
    {
        public CreateAccountValidator()
        {
              RuleFor(account => account.AccountNumber)
            .NotEmpty().WithMessage("AccountNumber cannot be empty.");

        RuleFor(account => account.IBAN)
            .NotEmpty().WithMessage("IBAN cannot be empty.")
            .Length(10, 20).WithMessage("IBAN length must be between 10 and 20 characters.");

        RuleFor(account => account.Balance)
            .GreaterThanOrEqualTo(0).WithMessage("Balance must be greater than or equal to 0.");

        RuleFor(account => account.AccountName)
            .NotEmpty().WithMessage("AccountName cannot be empty.")
            .MaximumLength(50).WithMessage("AccountName length cannot exceed 50 characters.");

        RuleFor(account => account.CurrencyType)
            .NotEmpty().WithMessage("CurrencyType cannot be empty.")
            .Length(3).WithMessage("CurrencyType must be 3 characters.");
        }
    }
}