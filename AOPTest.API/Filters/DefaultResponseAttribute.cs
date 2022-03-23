using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AOPTest.API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AOPTest.API.Filters
{
    public class DefaultResponseAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if(context.Result is not OkObjectResult)
                return;
                
            var value = ((OkObjectResult)context.Result).Value;

            var result = CreateDefaultResponse(value);

            context.Result = new JsonResult(result);
        }
        
        private BaseResponse<T> CreateDefaultResponse<T>(T data) where T : class
        {
            BaseResponse<T> response = new BaseResponse<T>
            {
                Data = data,
                HttpStatusCode = System.Net.HttpStatusCode.OK
            };

            return response;
        }
    }
}