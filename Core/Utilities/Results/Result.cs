using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public Result(bool isSuccess, string message) : this(isSuccess) //overload alternatifi olan diğer constructor method da çalışsın
        {
            this.Message = message;
        }

        public Result(bool isSuccess)
        {
            this.IsSuccess = isSuccess;    
        }

        public bool IsSuccess { get; }

        public string Message { get; }
    }
}
