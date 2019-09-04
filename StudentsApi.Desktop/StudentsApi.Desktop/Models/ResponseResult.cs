using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsApi.Desktop.Models
{
    public class ResponseResult
    {
        public bool IsSuccessful { get; set; }

        public string Message { get; set; }

        public ResponseResult(bool isSuccessful)
        {
            this.IsSuccessful = isSuccessful;
        }

        public ResponseResult(bool isSuccessful, string message)
        {
            IsSuccessful = isSuccessful;
            Message = message;
        }
    }
}
