using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AOPTest.API.DTOs;
using AOPTest.API.Validations;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AOPTest.API.Filters
{
    public class FluentValidate : ActionFilterAttribute
    {
        private readonly Type _validatorType;
        public FluentValidate(Type type)
        {
            if (typeof(IValidator).IsAssignableFrom(type))
                _validatorType = type;
            else
                throw new Exception("type of type is wrong");
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = context.ActionArguments.Values.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }
}