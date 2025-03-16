using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using package_manager.Models;

namespace package_manager.Data
{
    public class AppDbContext : DbContext
    {
        public string DbPath { get; }

        public AppDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "packagedb.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");

        public DbSet<Order> Orders { get; set; }

        public DbSet<DeliveryMethod> DeliveryMethods { get; set; }
        public DbSet<CustomerType> CustomerTypes { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }

        private void SetEagerLoading(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .Navigation(o => o.CustomerType)
                .AutoInclude();

            modelBuilder.Entity<Order>()
                .Navigation(o => o.DeliveryMethod)
                .AutoInclude();

            modelBuilder.Entity<Order>()
                .Navigation(o => o.OrderStatus)
                .AutoInclude();

            modelBuilder.Entity<Order>()
                .Navigation(o => o.PaymentMethod)
                .AutoInclude();
        }

        private void SeedEnumData<TEnum, TEntity>(ModelBuilder modelBuilder)
            where TEnum : Enum
            where TEntity : class
        {
            var entities = Enum.GetValues(typeof(TEnum))
                .Cast<TEnum>()
                .Select(e => Activator.CreateInstance(typeof(TEntity), e))
                .ToArray();

            modelBuilder.Entity<TEntity>().HasData(entities);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedEnumData<CustomerTypeEnum, CustomerType>(modelBuilder);
            SeedEnumData<DeliveryMethodEnum, DeliveryMethod>(modelBuilder);
            SeedEnumData<OrderStatusEnum, OrderStatus>(modelBuilder);
            SeedEnumData<PaymentMethodEnum, PaymentMethod>(modelBuilder);

            SetEagerLoading(modelBuilder);

        }
    }
}
