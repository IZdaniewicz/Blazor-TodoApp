using Microsoft.EntityFrameworkCore;
using TodoApp.Models;

namespace TodoApp;



public class DataContext: DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {}

    public DbSet<User> Users { get; set; }
    public DbSet<TodoItem> TodoItems { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
    
    public override int SaveChanges()
    {
        ChangeTracker.DetectChanges();
        return base.SaveChanges();
    }
}