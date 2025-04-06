using FluentValidation;
using IntraNet.Entities;

namespace IntraNet.Models.Validators
{
    public class EventQueryValidator : AbstractValidator<EventQuery>
    {
        private int[] allowedPageSizes = new[] { 5, 10, 15 };
        public EventQueryValidator()
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
