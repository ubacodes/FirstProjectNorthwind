# FirstProjectNorthwind

15.10.2023 FirstProjectNorthwind

17.10.2023 WebAPI
Güncelleme notları
+ CategoriesController -Added
+ OrdersController -Added
+ ProductsController -Modified


28.10.2023 EntityFramework Version Update
Güncelleme notları
+ Default IoC Container yapısı iptal edilip, Autofac IoC Container yapısı kuruldu. *AutofacBusinessModule
+ Validasyon kurallarını oluşturup parametre gelen entitylerin validasyon kurallarına göre denetlemek için ValidationTool yazıldı.

16.11.2023 Business Layer
Güncelleme notları
+ Business katmanında iş kurallarından Cross Cutting Concern işlemlerinin ayrılması ve temiz kod için AOP yapısı ve interceptorlar kuruldu.
+ ValidationAspect yazıldı. AspectInterceptorSelector yazıldı. MethodInterceptor ve MethodInterceptorBaseAttribute yazıldı.
+ AutofacBusinessModule içerisinde Aspectleri yakalabilmesi için talimat yazıldı.
+ Business katmanı fonksiyonlar (temel CRUD operasyonları) içerisinde plug-in olarak kullanılabilecek şekilde iş parçacıkları private olarak yazıldı.
+ İş parçacıklarını çalıştırması için iş motoru Core katmanı içerisinde Utilities altında yazıldı.
