using GraphQLTestingAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQLTestingAPI.AppContext;

public class AppDbContext : DbContext
{
    public DbSet<Post> Posts { get; set; }
    public DbSet<Author> Authors { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(
            "server=172.16.100.102;user=root;password=1;database=graphqlapitesting;", 
            new MySqlServerVersion(new Version(8, 0, 11))
        );
    }
}
