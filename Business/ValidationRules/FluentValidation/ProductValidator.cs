using Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            //Validasyon kuralları yer alıyor.
            //Dto nesneleri için de olabilir.
            RuleFor(p => p.ProductName).MinimumLength(2);
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);

            //CategoryId değeri 1 olduğu zaman Product'ın UnitPrice değeri >= 10 olmalıdır.
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryID == 1);

            //Kendi oluşturduğumuz kurallara uygun olmalı diyoruz.
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürün ismi 'A' harfi ile başlamalıdır.");
        }
        //Kendi kurallarımızı fonksiyonlar halinde oluşturabiliyoruz. 
        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }

    }
}
