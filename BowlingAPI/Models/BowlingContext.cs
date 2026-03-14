//use DbContext and database features
using Microsoft.EntityFrameworkCore;

//namespace for the Models folder
namespace BowlingAPI.Models;

//connection between the application and the database
public class BowlingContext : DbContext
{
    //receives database
    public BowlingContext(DbContextOptions<BowlingContext> options)
        : base(options)
    {
    }

    //use this to query and save bowler data
    public DbSet<Bowler> Bowlers { get; set; }

    //application to access team information
    public DbSet<Team> Teams { get; set; }
}