using GameStop.API.Model;
using Microsoft.EntityFrameworkCore;

namespace GameStop.API.Data;

public class GameStopContext : DbContext
{
    public GameStopContext() { }
    public GameStopContext(DbContextOptions<GameStopContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Game>()
            .HasMany(e => e.Orders)
            .WithMany(e => e.Games)
            .UsingEntity<GameOrder>();
    }

    public virtual DbSet<Account> Account { get; set; }
    public virtual DbSet<Game> Game { get; set; }
    public virtual DbSet<Order> Order { get; set; }
    public virtual DbSet<Review> Review { get; set; }
    public virtual DbSet<GameOrder> GameOrder { get; set; }
}