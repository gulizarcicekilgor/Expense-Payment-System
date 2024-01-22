using FluentValidation;
using WebApi.Models;

namespace WebApi.Business.ExpenseOperations.Validations
{
    public class CreateExpenseValidator : AbstractValidator<CreateExpenseModelRquest>
    {
        public CreateExpenseValidator()
        {


            RuleFor(expense => expense.ExpenseCode)
            .NotEmpty().WithMessage("ExpenseCode cannot be empty.")
            .MaximumLength(10).WithMessage("ExpenseCode must be at most 10 characters.");

            RuleFor(expense => expense.Amount)
                .GreaterThan(0).WithMessage("Amount must be greater than 0.");

            RuleFor(expense => expense.Currency)
                .NotEmpty().WithMessage("Currency cannot be empty.")
                .Length(3).WithMessage("Currency must be 3 characters.");

            RuleFor(expense => expense.Description)
                .NotEmpty().WithMessage("Description cannot be empty.")
                .MaximumLength(100).WithMessage("Description must be at most 100 characters.");

        }
    }
}