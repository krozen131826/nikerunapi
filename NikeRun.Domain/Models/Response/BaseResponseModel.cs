using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikeRun.Domain.Models.Response
{
    public class BaseResponseModel
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

        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<string>? ValidationErrors { get; set; }
    }
}
