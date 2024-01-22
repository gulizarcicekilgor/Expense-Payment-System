using FluentValidation;
using WebApi.Models;

namespace WebApi.Business.EftOperations.Validations
{
    public class UpdateEftValidator : AbstractValidator<EftupdatedModelRequest>
    {
        public UpdateEftValidator()
        {
        RuleFor(eft => eft.Description)
            .NotEmpty().WithMessage("Description cannot be empty.")
            .MaximumLength(50).WithMessage("Description length cannot exceed 50 characters.");

        }
    }
}