using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    //Db tabloları ile proje classlarını (entity) bağlamak
    //DbContext : EntityFramework içerisinde gelen base context classımız
    public class NorthwindContext : DbContext
    {
        //Step 1: Veritabanımın yolunu belirtmem gerekiyor. (OnConfiguring : Projenin hangi veritabanı ile ilişkili olduğunu belirtiyoruz.)
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = DESKTOP-P31V3C9\SQLEXPRESS; Database = Northwind; Trusted_Connection = true; Encrypt = false"); //ConnectionString kendi bilgisayarım
            //optionsBuilder.UseSqlServer(@"Server = UMUT-B-ALPAN\SQLEXPRESS; Database = Northwind; Trusted_Connection = true; Encrypt = false"); //Şirket bilgisayarım
        }

        //Step 2: Sırasıyla hangi entity'in database üzerinde hangi table'a karşılık geleceğini DbSet Property ile belirtmek
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Territory> Territories { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
