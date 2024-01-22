using FluentValidation;
using WebApi.Models;

namespace WebApi.Business.ExpenseOperations.Validations
{
    public class UpdateExpenseValidator : AbstractValidator<UpdateExpenseModelRquest>
    {
        public UpdateExpenseValidator()
        {

            {
                RuleFor(model => model.ExpenseStatus)
                    .Must(BeAValidExpenseStatus)
                    .WithMessage("ExpenseStatus must be one of the following values: Pending Approval, Approved, Rejected");
            }

            bool BeAValidExpenseStatus(string status)
            {
                return status == "Pending Approval" || status == "approved" || status == "Rejected";
            }


        }

    }
}