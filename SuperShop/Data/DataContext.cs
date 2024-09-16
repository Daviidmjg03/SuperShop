using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SuperShop.Data.Entities;
using System.Linq;

namespace SuperShop.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<OrderDetailTemp> orderDetailTemps { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<City> Cities { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modebuilder)
        {
            modebuilder.Entity<Country>()
                .HasIndex(c => c.Name)
                .IsUnique();

            modebuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            modebuilder.Entity<OrderDetailTemp>()
               .Property(p => p.Price)
               .HasColumnType("decimal(18,2)");

            modebuilder.Entity<OrderDetail>()
               .Property(p => p.Price)
               .HasColumnType("decimal(18,2)");



            base.OnModelCreating(modebuilder);
        }

        //HABILITAR A REGRA DE APAGAR EM CASCATA(CASCADE DELETE RULE)

        //protected override void OnModelCreating(ModelBuilder modeBuilder)
        //{
        //    var cascadeFKs = modeBuilder.Model.GetEntityTypes().SelectMany(t => t.GetForeignKeys()).Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);
        //    foreach( var fk in cascadeFKs)
        //    {
        //        fk.DeleteBehavior = DeleteBehavior.Restrict;
        //    }

        //    base.OnModelCreating(modeBuilder);
        //}
    }
}
