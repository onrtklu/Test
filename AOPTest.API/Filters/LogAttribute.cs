using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AOPTest.API.Controllers;
using AOPTest.API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AOPTest.API.Filters
{
    public class LogAttribute : ActionFilterAttribute
    {
        
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var model = context.ActionArguments.Values.ToList();

            var controller = context.Controller as BaseController;
            var userId = controller.GetCurrentUserId();

            var _logModel = context.HttpContext.RequestServices.GetService<ILogModel>();

            _logModel.Create(model, "asd", userId);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if(context.Result is not OkObjectResult)
                return;

            var value = ((OkObjectResult)context.Result).Value;

            var _logModel = context.HttpContext.RequestServices.GetService<ILogModel>();
            _logModel.Complete(value);
        }
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            base.OnResultExecuting(context);
        }
        public override void OnResultExecuted(ResultExecutedContext context)
        {
            base.OnResultExecuted(context);
        }
    }
}