using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace AOPTest.API.Model
{
    public interface ILogModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string RequestName { get; set; }
        void Create<T>(T model, string requestName, int? userId = 0) where T : class;
        void Complete<T>(T model) where T : class;
    }

    public class LogModel : ILogModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string RequestName { get; set; }
        public string RequestBody { get; set; }
        public string ResponseBody { get; set; }
        public int? UserId { get; set; }

        public void SetRequestBody<T>(T requestBody) where T : class
            => RequestBody = JsonSerializer.Serialize(requestBody);

        public void SetResponseBody<T>(T responseBody) where T : class
            => ResponseBody = JsonSerializer.Serialize(responseBody);
            
        public void Create<T>(T model, string requestName, int? userId = 0) where T : class
        {
            UserId = userId;
            SetRequestBody(model);
            RequestName = requestName;
            StartDate = DateTime.Now;
        }

        public void Complete<T>(T model) where T : class
        {
            SetResponseBody(model);
            EndDate = DateTime.Now;
        }
    }
}