//using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Text;
using TaskManager.Models;

namespace TaskManager.Context
{
    public class TaskManagerContext : DbContext
    {
        public TaskManagerContext() : base() { }

        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Group> Groups { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)//DbModelBuilder
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
                .HasMany(e => e.Groups)
                .WithMany(e => e.Users)
                .Map(ug =>
                {
                    ug.MapLeftKey("UserId");
                    ug.MapRightKey("GroupId");
                    ug.ToTable("UserGroup");
                });

            modelBuilder.Entity<User>()
                .HasMany(e => e.Tasks)
                .WithRequired(e => e.Publisher);

            #endregion


            //modelBuilder.Entity<User>().HasIndex(e => e.Name);

            //modelBuilder.Entity<User>()
            //    .HasIndex(e => e.Email)
            //    .IsUnique();


            #region Group

            modelBuilder.Entity<Group>()
                .Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsRequired();

            modelBuilder.Entity<Group>()
                .HasMany(e => e.Tasks)
                .WithRequired(e => e.Group);

            #endregion

            #region Task

            modelBuilder.Entity<Task>()
                .Property(e => e.Content)
                .HasMaxLength(500)
                .IsUnicode(false)
                .IsRequired();

            modelBuilder.Entity<Task>()
                .Property(e => e.PublicationDate);
                
            //modelBuilder.
                        //modelBuilder.Entity<Task>()
              //  .HasRequired(e => e.Publisher);
                
                
                //.WithRequiredPrincipal(t => t.);

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}

