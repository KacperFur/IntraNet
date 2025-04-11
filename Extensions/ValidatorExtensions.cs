using FluentValidation;
using IntraNet.Models.Validators;
using IntraNet.Models;

namespace IntraNet.Extensions
{
    public static class ValidatorExtensions
    {
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<CreateEmployeeDto>, CreateEmployeeDtoValidator>();
            services.AddScoped<IValidator<EmployeeQuery>, EmployeeQueryValidator>();
            services.AddScoped<IValidator<EmployeeTaskQuery>, EmployeeTaskQueryValidator>();
            return services;
        } 
    }
}
