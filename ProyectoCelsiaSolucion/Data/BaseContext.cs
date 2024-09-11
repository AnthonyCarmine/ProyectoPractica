using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProyectoCelsiaSolucion.Models;

namespace ProyectoCelsiaSolucion.Data
{
    public class BaseContext : IdentityDbContext<IdentityUser>
    {
        public BaseContext(DbContextOptions<BaseContext> options) : base(options)
        {
        }

        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}