using Microsoft.EntityFrameworkCore;
using ZooShop.Models;

namespace ZooShop.Logic;

public class MyDbContext : DbContext
{
    public DbSet<Pet> Pets { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<PetType> PetTypes { get; set; }

    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
    }
}

