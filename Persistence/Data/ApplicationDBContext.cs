﻿using Domain.Entities.Carts;
using Domain.Entities.Orders;
using Domain.Entities.Products;
using Domain.Entities.Users;
using Framework.Common.Roles;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
        : base(options)
    {
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserInRole> UserInRoles { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductImages> ProductImages { get; set; }
    public DbSet<ProductFeatures> ProductFeatures { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDBContext).Assembly);

        //Seed Data
        SeedData(modelBuilder);

        // اعمال ایندکس بر روی فیلد ایمیل
        // اعمال عدم تکراری بودن ایمیل
        modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();

        //-- عدم نمایش اطلاعات حذف شده
        ApplyQueryFilter(modelBuilder);
    }
    private void ApplyQueryFilter(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasQueryFilter(p => !p.IsRemoved);
        modelBuilder.Entity<Role>().HasQueryFilter(p => !p.IsRemoved);
        modelBuilder.Entity<UserInRole>().HasQueryFilter(p => !p.IsRemoved);
        modelBuilder.Entity<Category>().HasQueryFilter(p => !p.IsRemoved);
        modelBuilder.Entity<Product>().HasQueryFilter(p => !p.IsRemoved);
        modelBuilder.Entity<ProductImages>().HasQueryFilter(p => !p.IsRemoved);
        modelBuilder.Entity<ProductFeatures>().HasQueryFilter(p => !p.IsRemoved);
        modelBuilder.Entity<Cart>().HasQueryFilter(p => !p.IsRemoved);
        modelBuilder.Entity<CartItem>().HasQueryFilter(p => !p.IsRemoved);
        modelBuilder.Entity<Order>().HasQueryFilter(p => !p.IsRemoved);
        modelBuilder.Entity<OrderDetail>().HasQueryFilter(p => !p.IsRemoved);
    }
    private void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>().HasData(new Role { Id = 1, Name = nameof(UserRoles.Admin) });
        modelBuilder.Entity<Role>().HasData(new Role { Id = 2, Name = nameof(UserRoles.Operator) });
        modelBuilder.Entity<Role>().HasData(new Role { Id = 3, Name = nameof(UserRoles.Customer) });
    }
}
