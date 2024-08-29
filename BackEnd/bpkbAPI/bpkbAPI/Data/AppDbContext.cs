using Microsoft.EntityFrameworkCore;
using bpkbAPI.Models;

namespace bpkbAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ms_storage_location> ms_storage_location { get; set; }
        public DbSet<ms_user> ms_user { get; set; }
        public DbSet<tr_bpkb> tr_bpkb { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ms_storage_location>()
                .HasKey(m => m.location_id);

            modelBuilder.Entity<ms_user>()
                .HasKey(m => m.user_id);

            modelBuilder.Entity<ms_user>()
            .Property(u => u.user_id)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<tr_bpkb>()
                .HasKey(m => m.agreement_number);
        }
    }
}



