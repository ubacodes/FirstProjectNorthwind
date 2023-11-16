using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil!"); //AspectMessages.WrongValidationType
            }

            _validatorType = validatorType;
        }
        //Base class üzerindeki methodu override ederek üzerine yazdık.
        //Bu demektir ki, Validasyon işlemlerini OnBefore 'da yani business class içerisindeki fonksiyon işleme girmeden önce 
        //validasyon kurallarını çalıştır.
        protected override void OnBefore(IInvocation invocation)
        {
            //Attribute içerisinde typeof olarak verilen türü çalışma anında new'ler.
            var validator = (IValidator)Activator.CreateInstance(_validatorType);   //reflaction code

            //ProductValidator'un çalışma tipini bul. (Product)
            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; 

            //Attribute olarak verildiği methodun parametrelerini bul.
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);  
            
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
