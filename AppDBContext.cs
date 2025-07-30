using APIProduct.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace APIProduct
{
    public class AppDBContext : IdentityDbContext<UserApplication>
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> User { get; set; }
    }
}
