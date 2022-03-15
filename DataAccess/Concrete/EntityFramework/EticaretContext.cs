using System;
using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Color = Entities.Concrete.Color;

namespace DataAccess.Concrete.EntityFramework
{
    public class EticaretContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public EticaretContext(DbContextOptions<EticaretContext> dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        public EticaretContext()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                base.OnConfiguring(optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DArchMySqlContext")));
            }
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ETicaretDb;Trusted_Connection=true");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Color> Colors { get; set; }


        //public override int SaveChanges()
        //{
        //    var datas = ChangeTracker.Entries<BaseEntity>();
        //    foreach (var data in datas)
        //    {
        //        _ = data.State switch
        //        {
        //            EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow ,
        //            EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow,
                    
        //        };

        //    }
        //    return  base.SaveChanges();
        //}
    }
}



