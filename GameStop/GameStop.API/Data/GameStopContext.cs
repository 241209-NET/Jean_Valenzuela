using GameStop.API.Model;
using Microsoft.EntityFrameworkCore;

namespace GameStop.API.Data;

public class GameStopContext : DbContext
{
    public GameStopContext(){}
    public GameStopContext(DbContextOptions<GameStopContext> options) : base(options){}

    public virtual DbSet<Account> Accounts{ get; set; } 
    public virtual DbSet<Game> Games{ get; set; }
    public virtual DbSet<Order> Orders{ get; set; }
    public virtual DbSet<Review> Reviews{ get; set; }
}