using FluentValidation;
using IntraNet.Entities;

namespace IntraNet.Models.Validators
{
    public class CreateEmployeeDtoValidator : AbstractValidator<CreateEmployeeDto>
    {
        public CreateEmployeeDtoValidator(IntraNetDbContext dbContext)
        {
            RuleFor(e => e.Email).EmailAddress()
                .NotEmpty();
            RuleFor(e => e.FirstName).NotEmpty();
            RuleFor(e => e.LastName).NotEmpty();
            RuleFor(e=>e.Password).MinimumLength(8);
            RuleFor(e => e.Email).Custom((value, context) =>
            {
              var emailInUse = dbContext.Employees.Any(u => u.Email == value);  
                if(emailInUse)
                {
                    context.AddFailure("Email", "That email is already taken");
                }
            });
           
        }
    }
}
