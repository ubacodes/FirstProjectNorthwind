using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.Autofac;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using WebAPI;

var builder = WebApplication.CreateBuilder(args);

#region AutofacBusinessModule Kullan�m�
//Business Katman� -> DependencyResolvers -> Autofac -> AutofacBusinessModule 'u WebAPI katman�m�zda default olan IoC container yap�m�z�n yerine kullan�m� a�a��daki gibidir.
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new AutofacBusinessModule());
});
#endregion

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//.net 6.0 'dan sonra ayr�ca bir statup.cs dosyas� kullan�lm�yor. Bu y�zden IoC yap�lanmam�z� hemen a�a��da ger�ekle�tiriyoruz.
//IoC
//AddSingleton = i�erisinde data tutulmayacaksa kullan�labilir. Yani bir sepeti b�yle yapamazs�n. Herkesin sepeti tek olur.
//builder.Services.AddSingleton<IProductService, ProductManager>();
//builder.Services.AddSingleton<ICategoryService, CategoryManager>();
//builder.Services.AddSingleton<IOrderService, OrderManager>();

//builder.Services.AddSingleton<IProductDal, EfProductDal>();
//builder.Services.AddSingleton<ICategoryDal, EfCategoryDal>();
//builder.Services.AddSingleton<IOrderDal, EfOrderDal>();

var app = builder.Build();  //default builder

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//
app.UseAuthentication();

app.Run();
