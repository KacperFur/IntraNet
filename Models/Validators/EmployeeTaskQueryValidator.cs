﻿using FluentValidation;
using IntraNet.Entities;

namespace IntraNet.Models.Validators
{
    public class EmployeeTaskQueryValidator : AbstractValidator<EmployeeTaskQuery>
    {
        private int[] allowedPageSizes = new[] { 10, 15, 20 };
        public EmployeeTaskQueryValidator()
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
