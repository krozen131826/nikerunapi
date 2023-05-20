using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikeRun.Domain.Models.Response
{
    public class BaseResponseModel<T>
    {
        public BaseResponseModel()
        {
            Success = true;
        }
        public BaseResponseModel(string message)
        {
            Success = true;
            Message = message;
        }

        public BaseResponseModel(string message, bool success)
        {
            Success = success;
            Message = message;
        }

        public T? Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
