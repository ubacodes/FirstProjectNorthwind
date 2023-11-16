using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        //İş kurallarını çalıştıracak iş motoru
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.IsSuccess)
                {
                    return logic;
                }
            }
            return null;
        }
        #region Alternatif Yöntem II
        //public static List<IResult> Run(params IResult[] logics)  //Parametre olarak birden fazla iş kuralı alabilir. (Hatta kaç tane girildiyse dizi boyutu o kadar olacaktır.)
        //{
        //    List<IResult> errorResults = new List<IResult>();

        //    foreach (var logic in logics) 
        //    {
        //        if (!logic.IsSuccess) 
        //        {
        //            errorResults.Add(logic);
        //            //Başarılı olarak geçemediği iş kuralını errorResults içerisine ekliyoruz.
        //            //(Zaten iş kurallarımız da IResult return ediyor dolayısıyla ErrorResult dönecektir.)
        //        }

        //    }

        //    return errorResults;
        //}
        #endregion
    }
}
