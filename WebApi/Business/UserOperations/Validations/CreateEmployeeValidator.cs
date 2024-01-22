using FluentValidation;
using WebApi.Models;

namespace WebApi.Business.EmployeeOperations.Validations
{
    public class CreateEmployeeValidator : AbstractValidator<CreateEmployeeModelRequest>
    {
        public CreateEmployeeValidator()
        {
            RuleFor(model => model.FirstName)
            .NotEmpty().WithMessage("FirstName cannot be empty.")
            .MaximumLength(50).WithMessage("FirstName must be at most 50 characters.");

            RuleFor(model => model.LastName)
                .NotEmpty().WithMessage("LastName cannot be empty.")
                .MaximumLength(50).WithMessage("LastName must be at most 50 characters.");

            RuleFor(model => model.UserName)
                .NotEmpty().WithMessage("UserName cannot be empty.")
                .MaximumLength(20).WithMessage("UserName must be at most 20 characters.");

            RuleFor(model => model.Password)
                .NotEmpty().WithMessage("Password cannot be empty.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters.");

            RuleFor(model => model.IdentityNumber)
                .NotEmpty().WithMessage("IdentityNumber cannot be empty.")
                .GreaterThan(0).WithMessage("IdentityNumber must be greater than 0.");

            RuleFor(model => model.Email)
                .NotEmpty().WithMessage("Email cannot be empty.")
                .EmailAddress().WithMessage("Invalid email address.")
                .Must(BeAValidEmail).WithMessage("Invalid email address format.");
            RuleFor(model => model.Roles)
                   .Must(BeAValidRole).WithMessage("Roles must be either 'employee' or 'admin'.");
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




        private bool BeAValidRole(string role)
        {
            return role == "employee" || role == "admin";
        }

    }
}