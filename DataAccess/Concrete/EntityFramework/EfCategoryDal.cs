using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, NorthwindContext>, ICategoryDal
    //Bu class EfEntityRepositoryBase class'ından inherit ediliyor. Aynı zamanda ICategoryDal imzası taşıyor.
    //EfEntityRepositoryBase ise EntityFramework kullanılarak yürütülen CRUD operasyonlarını generic bir yapıda taşıyor.    
    {
    }
}
