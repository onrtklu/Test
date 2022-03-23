using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AOPTest.API.Model
{
    public class BaseResponse<T>
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public string HttpStatusCodeName => HttpStatusCode.ToString();
        public string Message { get; set; }
        public T Data { get; set; }
    }
}