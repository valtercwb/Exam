using Microsoft.EntityFrameworkCore;
using VolvoExam.Data.Entities;

namespace VolvoExam.Data
{
  public class VolvoExamDbContext : DbContext
  {
    public VolvoExamDbContext(DbContextOptions<VolvoExamDbContext> options) : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }

    public DbSet<Truck> Truck { get; set; }
    public DbSet<TruckModel> TruckModel { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.UseSerialColumns();

      modelBuilder.Entity<Truck>();
      modelBuilder.Entity<TruckModel>();
    }
  }
}