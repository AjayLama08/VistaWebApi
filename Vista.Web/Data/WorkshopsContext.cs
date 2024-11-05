using Microsoft.EntityFrameworkCore;
using Vista.Web.Data.Vista.Web.Data;

namespace Vista.Web.Data
{
    public class WorkshopsContext : DbContext
    {
        public string DbPath { get; set; }
        public WorkshopsContext()
        {
            var folder = Environment.SpecialFolder.MyDocuments;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "workshops.db");
        }
        public DbSet<Workshop> Workshops { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<WorkshopStaff> WorkshopStaff { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<WorkshopStaff>()
            .HasKey(ws => new { ws.WorkshopId, ws.StaffId });
            // define many to many
            modelBuilder.Entity<WorkshopStaff>()
            .HasOne(ws => ws.Staff)
            .WithMany(ws => ws.Workshops)
            .HasForeignKey(ws => ws.StaffId);
            modelBuilder.Entity<WorkshopStaff>()
            .HasOne(sp => sp.Workshop)
            .WithMany(sp => sp.Staff)
            .HasForeignKey(sp => sp.WorkshopId);
            modelBuilder.Entity<Staff>().HasData(
            new Staff(1, "MacGrory", "Shripati"),
            new Staff(2, "Martinsson", "Nani"),
            new Staff(3, "Presley", "Harrison"),
            new Staff(4, "Orr", "Theo"),
            new Staff(5, "Metcalfe", "Drew")
            );
            modelBuilder.Entity<Workshop>().HasData(
            new Workshop(1, "Excel (Beginner)", new DateTime(2023, 01, 10, 10, 0, 0)),
            new Workshop(2, "Excel (Intermediate)", new DateTime(2023, 01, 11, 10,
            0, 0)),
            new Workshop(3, "Word (Beginner)", new DateTime(2023, 09, 01, 12, 0, 0))
            );
            modelBuilder.Entity<WorkshopStaff>().HasData(
            new WorkshopStaff(1, 1),
            new WorkshopStaff(1, 2),
            new WorkshopStaff(2, 1),
            new WorkshopStaff(2, 2),
            new WorkshopStaff(2, 4),
            new WorkshopStaff(3, 4)
            );
        }
    }
}
