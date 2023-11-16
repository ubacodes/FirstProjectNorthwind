using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
        //where class: referans tip | IEntity : yani bu generic yapı IEntity olabilir yada IEntity implemente eden bir nesne yapısı olabilir
        //new() : new'lenebilir olmalı
    {
        //Expression GetAll methodu çağırıldığı zaman içerisinde linq sorgulamarı ile filtreleme uygulayarak veritabanından dataları çekmemizde yardımcı olacak.
        //Linq.Expression kütüphanesi ile birlikte gelir.
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        //Get Methodu genellikle tek bir kayıda erişmek için kullanıldığından dolayı istenilen kayıdın ayırt edici olan yani unique olan değeri ile çağırılarak
        //kayıda erişim sağlanmasını amaçlıyoruz.
        T Get(Expression<Func<T, bool>> filter);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
