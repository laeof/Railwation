using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<City> Cities { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<CityCrossing> CityCrossings { get; set; }
    public DbSet<BorderCrossing> BorderCrossings { get; set; }
    public DbSet<CityConnection> CityConnections { get; set; }
    public DbSet<CountryConnection> RailConnections { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
