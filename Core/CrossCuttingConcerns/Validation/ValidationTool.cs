using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator, object entity) 
        {
            //Gönderilen entity için validasyon kurallarını çalıştırmak üzere Context yapısı oluşturuyoruz.
            var context = new ValidationContext<object>(entity);

            //Gönderilen entity için gönderilen validator içerisinde bulunan kuralları, validate et. Sonucunu (IsValid = bool) result içerisinde tut.
            var result = validator.Validate(context);

            //Eğer validasyon sonucunda IsValid değerimiz false ise entity iş kurallarının uygulanması için uygun değildir ve bir hata fırlat.
            if(!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
