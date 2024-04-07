using EventOrganize.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BusinessLogic.Entities;

namespace BusinessLogic.Context
{
    public partial class EventOrganizerDbContext : DbContext
    {
        public EventOrganizerDbContext() { }

        public EventOrganizerDbContext(DbContextOptions<EventOrganizerDbContext> options)
        : base(options)
        {
        }

        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Event>().HasData(
                new Event
                {
                    Id = 1,
                    Name = "Event 1",
                    Date = DateTime.UtcNow,
                    Hour = DateTime.UtcNow,
                    Localization = "Local 1",
                    Description = "Description 1",
                    MaxCapacity = 100,
                    OwnerId = 1,
                    CategoryId = 1
                },
                new Event
                {
                    Id = 2,
                    Name = "Event 2",
                    Date = DateTime.UtcNow,
                    Hour = DateTime.UtcNow,
                    Localization = "Local 2",
                    Description = "Description 2",
                    MaxCapacity = 200,
                    OwnerId = 2,
                    CategoryId = 2
                }
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "Tiago Oliveira",
                    Email = "contacto.tiagooliveira@gmail.com",
                    Password = "tiago123456",
                    PasswordHash = "",
                    Type = UserType.Organizer
                },
                new User
                {
                    Id = 2,
                    Name = "Eduardo Gomes",
                    Email = "eduardo@gmail.com",
                    Password = "eduardo123456",
                    PasswordHash = "",
                    Type = UserType.Organizer
                }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Games"
                },
                new Category
                {
                    Id = 2,
                    Name = "Music"
                }
            );





            modelBuilder.Entity<Event>().ToTable("tb_vent");
            modelBuilder.Entity<Activity>().ToTable("tb_activity");
            modelBuilder.Entity<Ticket>().ToTable("tb_ticket");
            modelBuilder.Entity<User>().ToTable("tb_user");
            modelBuilder.Entity<Category>().ToTable("tb_category");

            modelBuilder.Entity<Event>()
                .HasOne(e => e.Owner)
                .WithMany(u => u.Events).IsRequired();
            modelBuilder.Entity<Event>()
                .HasMany(e => e.Activities)
                .WithOne(a => a.Event);
            modelBuilder.Entity<Event>()
                .HasMany(e => e.Tickets)
                .WithOne(t => t.Event);
            modelBuilder.Entity<Event>()
                .HasOne(e => e.Category)
                .WithMany(c => c.Events);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Event)
                .WithMany(e => e.Tickets).IsRequired();
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Owner)
                .WithMany(u => u.Tickets);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Events)
                .WithOne(e => e.Owner);
            modelBuilder.Entity<User>()
                .HasMany(u => u.Tickets)
                .WithOne(t => t.Owner);


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
