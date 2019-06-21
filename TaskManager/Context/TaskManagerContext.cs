using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Text;

namespace TaskManager.Models
{
    public class TaskManagerContext : DbContext
    {
        public TaskManagerContext() : base() { }

        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Group> Groups { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(e => e.Name)
                .IsRequired();

            //modelBuilder.Entity<User>()
            //    .HasIndex(e => e.Email)
            //    .IsUnique();

            modelBuilder.Entity<User>()
                 .Property(e => e.Email)
                 .IsRequired();
                

            modelBuilder.Entity<User>()
                .Property(e => e.HashPassword)
                .HasMaxLength(88)
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


            /*
                modelBuilder.Entity<Groups>()
                            .HasMany(e => e.People)
                            .WithOptional(e => e.Groups1)
                            .HasForeignKey(e => e.GroupId)
                            .WillCascadeOnDelete();

                        modelBuilder.Entity<People>()
                            .Property(e => e.FirstName)
                            .IsUnicode(false);

                        modelBuilder.Entity<People>()
                            .Property(e => e.LastName)
                            .IsUnicode(false);

                        modelBuilder.Entity<People>()
                            .Property(e => e.Position)
                            .IsUnicode(false);

                        modelBuilder.Entity<People>()
                            .HasMany(e => e.Groups)
                            .WithRequired(e => e.People1)
                            .HasForeignKey(e => e.MentorId)
                            .WillCascadeOnDelete(false);*/
            base.OnModelCreating(modelBuilder);
        }
    }
}

