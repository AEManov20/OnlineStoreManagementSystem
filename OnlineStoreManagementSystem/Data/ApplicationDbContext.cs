using Microsoft.EntityFrameworkCore;
using OnlineStoreManagementSystem.Entities;

namespace OnlineStoreManagementSystem.Data;

public class ApplicationDbContext(DbContextOptions opt) : DbContext(opt)
{
    public DbSet<Customer> Customers { get; set; }
    
    public DbSet<DigitalProduct> DigitalProducts { get; set; }
    
    public DbSet<PhysicalProduct> PhysicalProducts { get; set; }

    public DbSet<Order> Orders { get; set; }
    
    public DbSet<DigitalProductOrder> DigitalProductOrders { get; set; }
    
    public DbSet<PhysicalProductOrder> PhysicalProductOrders { get; set; }
    
    public DbSet<DiscountCode> DiscountCodes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // seed anything else into the database
        // TODO: seed root/superadmin identity
    }
}