using Microsoft.EntityFrameworkCore;
using TaskManager.DAL.Models;

namespace TaskManager.DAL.Context
{
    public class TaskManagerContext : DbContext
    {
        public TaskManagerContext() : base() { }

        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Group> Groups { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=TaskManager;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region User
            modelBuilder.Entity<User>()
                .Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();

            modelBuilder.Entity<User>()
                 .Property(e => e.Email)
                 .HasMaxLength(254)
                 .IsUnicode(false)
                 .IsRequired();

            modelBuilder.Entity<User>()
                .Property(e => e.HashPassword)
                .HasMaxLength(88)
                .IsUnicode(false)
                .IsRequired();

          
            modelBuilder.Entity<User>()
                .HasMany(e => e.Tasks);

            #endregion
            
            #region Group

            modelBuilder.Entity<Group>()
                .Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsRequired();


            modelBuilder.Entity<Group>()
                .HasMany(e => e.Tasks);

            #endregion

            #region UserGrop

            modelBuilder.Entity<UserGroup>()
                .HasKey(ug => new { ug.UserId, ug.GroupId });

            modelBuilder.Entity<UserGroup>()
                .HasOne(ug => ug.User)
                .WithMany(u => u.UserGroups)
                .HasForeignKey(bc => bc.UserId);

            modelBuilder.Entity<UserGroup>()
                .HasOne(ug => ug.Group)
                .WithMany(g => g.UserGroups)
                .HasForeignKey(ug => ug.GroupId);

            #endregion

            #region Task

            modelBuilder.Entity<Task>()
                .Property(e => e.Content)
                .HasMaxLength(500)
                .IsUnicode(false)
                .IsRequired();

        
            modelBuilder.Entity<Task>()
                .Property(e => e.PublicationDate);

            #endregion

            #region SeedData
            
            //modelBuilder.Entity<User>().HasData(
            //    new User { Id=1, Name = "Bohdan", Email = "bohdan@gmail.com", HashPassword = "1" },
            //    new User { Id=2, Name = "Mom", Email = "mom@gmail.com", HashPassword = "1" }
            //    );

            //modelBuilder.Entity<Group>().HasData(
            //    new Group { Id=1, Title = "Family" },
            //    new Group { Id=2, Title = "Lv-420.Net" }
            //    );

            //modelBuilder.Seed();

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}

