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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO refactoring 
            //var enumMappings = new List<(Type EnumType, Type EntityType)>
            //{
            //    (typeof(OrderStatusEnum), typeof(OrderStatus)),
            //    (typeof(PaymentMethodEnum), typeof(PaymentMethod)),
            //    (typeof(CustomerTypeEnum), typeof(CustomerType)),
            //    (typeof(DeliveryMethodEnum), typeof(DeliveryMethod))
            //};

            //foreach (var (enumType, entityType) in enumMappings)
            //{
            //    SeedEnumData(modelBuilder, enumType, entityType);
            //}

            foreach (var e in Enum.GetValues(typeof(CustomerTypeEnum)).Cast<CustomerTypeEnum>())
            {
                modelBuilder.Entity<CustomerType>().HasData(new CustomerType(e));
            }

            foreach (var e in Enum.GetValues(typeof(DeliveryMethodEnum)).Cast<DeliveryMethodEnum>())
            {
                modelBuilder.Entity<DeliveryMethod>().HasData(new DeliveryMethod (e));
            }

            foreach (var e in Enum.GetValues(typeof(OrderStatusEnum)).Cast<OrderStatusEnum>())
            {
                modelBuilder.Entity<OrderStatus>().HasData(new OrderStatus (e));
            }

            foreach (var e in Enum.GetValues(typeof(PaymentMethodEnum)).Cast<PaymentMethodEnum>())
            {
                modelBuilder.Entity<PaymentMethod>().HasData(new PaymentMethod (e));
            }
        }
    }
}
