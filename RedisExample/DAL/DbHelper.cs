using Microsoft.EntityFrameworkCore;
using RedisExample.DAL.Models;

namespace RedisExample.DAL;

public class DbHelper:DbContext
{
    
    public DbSet<ProductModel> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=RedisTest;Username=postgres;Password=Vomber123");
    }
}