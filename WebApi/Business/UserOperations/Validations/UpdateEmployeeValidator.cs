using FluentValidation;
using WebApi.Models;

namespace WebApi.Business.EmployeeOperations.Validations
{
    public class UpdateEmployeeValidator : AbstractValidator<UpdateEmployeeModelRequest>
    {
        public UpdateEmployeeValidator()
        {

            RuleFor(model => model.LastName)
                .NotEmpty().WithMessage("LastName cannot be empty.")
                .MaximumLength(50).WithMessage("LastName must be at most 50 characters.");

            RuleFor(model => model.UserName)
                .NotEmpty().WithMessage("UserName cannot be empty.")
                .MaximumLength(20).WithMessage("UserName must be at most 20 characters.");

            RuleFor(model => model.Password)
                .NotEmpty().WithMessage("Password cannot be empty.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters.");

            RuleFor(model => model.Email)
                .NotEmpty().WithMessage("Email cannot be empty.")
                .EmailAddress().WithMessage("Invalid email address.")
                .Must(BeAValidEmail).WithMessage("Invalid email address format.");
        }

        private bool BeAValidEmail(string email)
        {
            try
            {
                var address = new System.Net.Mail.MailAddress(email);
                return address.Address == email;
            }
            catch
            {
                return false;
            }
        }

    }
}