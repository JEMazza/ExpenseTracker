
using Microsoft.EntityFrameworkCore;

namespace ExpenseServices.Entities {
    public class ExpenseContext:DbContext {

        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseType> ExpenseTypes { get; set; }
        public DbSet<ExpensePlace> ExpensePlaces { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            string dataString;
            #if DEBUG
            dataString = "Expenses.db";
            #else
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string appFolder = Path.Combine(appData, "Expense Tracker");
            Directory.CreateDirectory(appFolder);
            datastring = Path.Combine(appFolder, "Expenses.db");
            #endif
            optionsBuilder.UseSqlite($"Data Source={dataString}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<ExpenseType>().ToTable("Types");
            modelBuilder.Entity<ExpenseType>().Property(et => et.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<ExpenseType>().Property(et => et.Name).IsRequired();
            modelBuilder.Entity<ExpenseType>().HasKey(et => et.Id);
            modelBuilder.Entity<ExpenseType>().HasIndex(et => et.Name);

            modelBuilder.Entity<ExpensePlace>().ToTable("Places");
            modelBuilder.Entity<ExpensePlace>().Property(ep => ep.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<ExpensePlace>().Property(ep => ep.Name).IsRequired();
            modelBuilder.Entity<ExpensePlace>().HasKey(ep => ep.Id);
            modelBuilder.Entity<ExpensePlace>().HasIndex(ep => ep.Name);

            modelBuilder.Entity<Expense>().ToTable("Expenses");
            modelBuilder.Entity<Expense>().Property(e => e.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Expense>().Property(e => e.Name).IsRequired();
            modelBuilder.Entity<Expense>().Property(e => e.Date).IsRequired();
            modelBuilder.Entity<Expense>().Property(e => e.TypeId).IsRequired();
            modelBuilder.Entity<Expense>().Property(e => e.Cost).IsRequired();
            modelBuilder.Entity<Expense>().HasKey(e => e.Id);
            modelBuilder.Entity<Expense>().HasIndex(e => e.Date);
            modelBuilder.Entity<Expense>().HasIndex(e => e.TypeId);
            modelBuilder.Entity<Expense>().HasIndex(e => e.PlaceId);

            modelBuilder.Entity<ExpenseType>().HasMany(et => et.Expenses).WithOne(e => e.Type).HasForeignKey(e => e.TypeId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ExpensePlace>().HasMany(et => et.Expenses).WithOne(e => e.Place).HasForeignKey(e => e.PlaceId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
