using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AOPTest.API.Utilities;
using FluentValidation;
using FluentValidation.Results;

namespace AOPTest.API.Validations
{
    public static class Validate<T,K> where T : AbstractValidator<K>, new ()
    {
        public static void Valid(K model)
        {
            T validator = Singleton<T>.Instance;
            ValidationResult validationResult = validator.Validate(model);
            if (!validationResult.IsValid)
                throw new Exception(string.Join(";", validationResult.Errors.Select(s=>s.ErrorMessage)));
        }
    }

    public static class ValidationTool
    {
        public static void Validate<T>(IValidator validator, T entity) where T : class, new()
        {
            var result = validator.Validate(new ValidationContext<T>(entity));
            if (!result.IsValid)
            {
                throw new Exception(string.Join(";", result.Errors.Select(s=>s.ErrorMessage)));
            }
        }
    }
}