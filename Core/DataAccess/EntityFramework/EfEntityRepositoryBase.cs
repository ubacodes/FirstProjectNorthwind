using Core.Entities;
using Microsoft.EntityFrameworkCore;        //NuGetPackages ile EntityFrameworkCore.SqlServer Core katmanına kuruldu
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()   //Parametre olarak verilebilecek generic yapılı Entity'nin koşulları
        where TContext : DbContext, new()   //Parametre olarak verilebilecek generic yapılı Context'in koşulları
    {

        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);    //Entity'in referansını tabloda yakalama.
                addedEntity.State = EntityState.Added;  //Bu nesneyi eklenecek olarak işaretle.
                context.SaveChanges();  //Yapılan işlemleri tabloya yansıt.
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
                //Ternary operatörü sayesinde filter içerisindeki değer eğer null ise Product tablosuna eriş ve tüm datayı getir.
                //Eğer null değil bir filtre var ise .Where ile bu filtreyi uygulayarak getir.
            }
        }
    }
}
