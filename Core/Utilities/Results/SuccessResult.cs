using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class SuccessResult : Result
    {   //Temel void türü işlemlerin return değerleri için kullanılabilir. 
        public SuccessResult(string message) : base(true, message)
        {           
        }
        public SuccessResult() : base(true)
        {            
        }
    }
}
