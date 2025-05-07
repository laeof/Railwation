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
    public DbSet<CountryConnection> CountryConnections { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<BorderCrossing>()
            .HasOne(b => b.CountryA)
            .WithMany(b => b.BorderCrossingsAsA)
            .HasForeignKey(b => b.CountryAId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<BorderCrossing>()
            .HasOne(b => b.CountryB)
            .WithMany(b => b.BorderCrossingsAsB)
            .HasForeignKey(b => b.CountryBId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<CityConnection>()
            .HasOne(b => b.FromCity)
            .WithMany(b => b.FromCityConnections)
            .HasForeignKey(b => b.FromCityId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<CityConnection>()
            .HasOne(b => b.ToCity)
            .WithMany(b => b.ToCityConnections)
            .HasForeignKey(b => b.ToCityId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<CountryConnection>()
            .HasOne(b => b.FromCountry)
            .WithMany(b => b.FromCountryConnections)
            .HasForeignKey(b => b.FromCountryId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<CountryConnection>()
            .HasOne(b => b.ToCountry)
            .WithMany(b => b.ToCountryConnections)
            .HasForeignKey(b => b.ToCountryId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
