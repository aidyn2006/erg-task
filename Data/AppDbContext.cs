using ERG_Task.Models;
using Microsoft.EntityFrameworkCore;

namespace ERG_Task.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Event> Events { get; set; }
        public DbSet<EventHistory> EventHistories { get; set; }
        public DbSet<Genealogy> Genealogy { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceHistory> InvoiceHistories { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<PackageHistory> PackageHistories { get; set; }
        public DbSet<Supply> Supplies { get; set; }
        public DbSet<Train> Trains { get; set; }
        public DbSet<TrainHistory> TrainHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
