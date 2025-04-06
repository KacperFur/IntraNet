using FluentValidation;
using IntraNet.Entities;

namespace IntraNet.Models.Validators
{
    public class EmployeeQueryValidator : AbstractValidator<EmployeeQuery>
    {
        private int[] allowedPageSizes = new[] { 10, 15, 20 };
        public EmployeeQueryValidator()
        {
            RuleFor(x=>x.PageNumber).GreaterThanOrEqualTo(1);
            RuleFor(x=>x.PageSize).Custom((value,context)=>
            {
                if(!allowedPageSizes.Contains(value))
                {
                    context.AddFailure("PageSize", $"Page size must be in [{string.Join(",", allowedPageSizes)}]");
                }
            });
        }
    }
}
