using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AOPTest.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        public int GetCurrentUserId()
        {
            // var customerId = User.FindFirst(ClaimTypes.Sid)?.Value;
            
            // int id = customerId.ToInt();

            // return id;
            return 19;
        }
    }
}