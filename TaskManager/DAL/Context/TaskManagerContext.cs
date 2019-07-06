using Microsoft.EntityFrameworkCore;
using System;
using TaskManager.DAL.Models;

namespace TaskManager.DAL.Context
{
    /// <summary>
    /// Application context.
    /// </summary>
    public class TaskManagerContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TaskManagerContext"/> class.
        /// </summary>
        public TaskManagerContext()
            : base()
        {
        }

        /// <summary>
        /// Gets or sets set of records in table Users.
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Gets or sets set of records in table Tasks.
        /// </summary>
        public DbSet<Task> Tasks { get; set; }

        /// <summary>
        /// Gets or sets set of records in table Groups.
        /// </summary>
        public DbSet<Group> Groups { get; set; }

        /// <summary>
        /// Gets or sets set of records in table UserGroups.
        /// </summary>
        public DbSet<UserGroup> UserGroups { get; set; }

        /// <inheritdoc/>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=TaskManager;Trusted_Connection=True;");
        }

        /// <inheritdoc/>
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

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Bohdan", Email = "bohdan@gmail.com", HashPassword = "10713417811525552252225157107128782559063877117316423416247297319230822211831359175" },
                new User { Id = 2, Name = "Mom", Email = "mom@gmail.com", HashPassword = "10713417811525552252225157107128782559063877117316423416247297319230822211831359175" });

            modelBuilder.Entity<Group>().HasData(
                new Group { Id = 1, Title = "Family" },
                new Group { Id = 2, Title = "Lv-420.Net" });

            modelBuilder.Entity<Task>().HasData(
                new Task
                {
                    Id = 1,
                    Content = "buy bread",
                    GroupId = 1,
                    IsDone = false,
                    PublicationDate = Convert.ToDateTime("03-07-2019"),
                    PublisherId = 2
                },
                new Task
                {
                    Id = 2,
                    Content = "do e-learnings",
                    GroupId = 2,
                    IsDone = false,
                    PublicationDate = Convert.ToDateTime("03-07-2019"),
                    PublisherId = 1
                });

            modelBuilder.Entity<UserGroup>().HasData(
                new UserGroup { UserId = 1, GroupId = 1 },
                new UserGroup { UserId = 1, GroupId = 2 },
                new UserGroup { UserId = 2, GroupId = 1 });

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}