using GraphQLTestingAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQLTestingDataLayer.AppContext;

public class AppDbContext : DbContext
{
    public DbSet<Post> Posts { get; set; }
    public DbSet<Author> Authors { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    
    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     
    // }
}
