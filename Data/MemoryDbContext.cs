using Microsoft.EntityFrameworkCore;
using MemoriesApp.Data;

public class MemoryDbContext : DbContext
{
    public MemoryDbContext(DbContextOptions<MemoryDbContext> options) : base(options) { }

    public DbSet<MemoryFile> MemoryFiles { get; set; }
}
