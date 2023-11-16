using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    //Temel void türü işlemlerin return değerleri için kullanılabilir.
    public interface IResult
    {
        bool IsSuccess { get; }
        string Message { get; } //sadece okunabilir.
    }
}
