using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class ErrorResult : Result
    {   //Temel void türü işlemlerin return değerleri için kullanılabilir.
        public ErrorResult(string message) : base(false, message)
        {            
        }
        public ErrorResult() : base(false)
        {            
        }
    }
}
