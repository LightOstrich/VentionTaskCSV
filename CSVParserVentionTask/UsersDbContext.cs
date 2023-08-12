using Microsoft.EntityFrameworkCore;

namespace CSVParserVentionTask;

public class UsersDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public UsersDbContext(DbContextOptions<UsersDbContext> options)
        : base(options)
    {
    }
    
}