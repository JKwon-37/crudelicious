#pragma warning disable CS8618

using Microsoft.EntityFrameworkCore;
namespace Crudelicious.Models;
// the MyContext class representing a session with our MySQL database, allowing us to query for or save data
public class CrudeliciousContext : DbContext 
{ 
    public CrudeliciousContext(DbContextOptions options) : base(options) { }
    // the "Dish" table name will come from the DbSet property name
    
    public DbSet<Dish> Dishes { get; set; } 
}
