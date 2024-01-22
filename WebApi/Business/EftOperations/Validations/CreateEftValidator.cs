using FluentValidation;
using WebApi.Models;

namespace WebApi.Business.EftOperations.Validations
{
    public class CreateEftValidator : AbstractValidator<EftTransactionRequest>
    {
        public CreateEftValidator()
        {

        RuleFor(eft => eft.Amount)
            .GreaterThanOrEqualTo(0).WithMessage("Amount must be greater than or equal to 0.");

        RuleFor(eft => eft.Description)
            .NotEmpty().WithMessage("Description cannot be empty.")
            .MaximumLength(50).WithMessage("Description length cannot exceed 50 characters.");

        }
    }
}