using Microsoft.EntityFrameworkCore;
using AtTheSeams.Data.Models;


namespace AtTheSeams.Data.Connections
{
    public class ClientContext : DbContext
    {
        public DbSet<ClientInfo> Clients { get; set; }
        public DbSet<ClientMeasurements> Measurements { get; set; }


        private static string DbPath { get; set; } =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AtTheSeams.db");
        public ClientContext(DbContextOptions<ClientContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public ClientContext() { }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlite($"Data Source={DbPath}");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientMeasurements>()
                .HasOne(cm => cm.Client)   // A Measurement belongs to one Client
                .WithMany(c => c.Measurements)  // A Client can have many Measurements
                .HasForeignKey(cm => cm.ClientId)  // Foreign Key
                .OnDelete(DeleteBehavior.Cascade); // Delete all Measurements if a Client is deleted
        }
    }
}
