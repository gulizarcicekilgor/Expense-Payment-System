using FluentValidation;
using WebApi.Models;

namespace WebApi.Business.AccountOperations.Validations
{
    public class UpdateAccountValidator : AbstractValidator<AccountupdatedModelRequest>
    {
        public UpdateAccountValidator()
        {

        RuleFor(account => account.AccountName)
            .NotEmpty().WithMessage("AccountName cannot be empty.")
            .MaximumLength(50).WithMessage("AccountName length cannot exceed 50 characters.");

        RuleFor(account => account.CurrencyType)
            .NotEmpty().WithMessage("CurrencyType cannot be empty.")
            .Length(3).WithMessage("CurrencyType must be 3 characters.");
        }
    }
}