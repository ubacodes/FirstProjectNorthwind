using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    //Biz projelerimizdeki bağımlılıklarımızı çözümleyebilmek için Autofac'den yararlanıyoruz.
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //RegisterType : Hangi Interface'e karşılık hangi Manager'ın oluşturulacağını söylüyoruz.
            //SingleInstance : Bir tane instance oluşturur. (Data tutulacak ise kullanılmamalıdır!)
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<OrderManager>().As<IOrderService>().SingleInstance();

            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();
            builder.RegisterType<EfOrderDal>().As<IOrderDal>().SingleInstance();

            //Autofac yukarıda her IoC Container için her interface için belirttiğimiz bir class'ın instance'ını singleInstance olarak
            //verirken bu her interface'ler için AspectSelector oluşturuyor yani bizim yazdığımız Aspectleri görebilmemizi ve çalıştıra-
            //bilmesini sağlıyor. 
            //[ValidationAspect(typeof(ProductValidator))]  <- productManager içerisindeki Add methodu üzerindeki bu aspect'i farketdip
            //çalıştırıyor.
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
