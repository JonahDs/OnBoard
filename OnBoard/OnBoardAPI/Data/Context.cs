using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnBoardAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardAPI.Data
{
    public class Context : IdentityDbContext
    {
        public DbSet<Order> Order { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Flight> Flight { get; set; }
        public DbSet<Seat> Seat { get; set; }
        public DbSet<User> User { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Passenger>();
            builder.Entity<CrewMember>();
            builder.Entity<User>().HasDiscriminator<string>("User_Type");

            builder.Entity<OrderDetail>().HasKey(shared => new
            {
                shared.OrderId, shared.ProductId
            });
            builder.Entity<OrderDetail>().HasOne(t => t.Product).WithMany();
            builder.Entity<OrderDetail>().HasOne(t => t.Order).WithMany(t => t.OrderDetails);
            builder.Entity<Order>().HasMany(t => t.OrderDetails);
            builder.Entity<Passenger>().HasMany(t => t.Messages).WithOne().HasForeignKey(t => t.SenderId);


        }
    }




}
