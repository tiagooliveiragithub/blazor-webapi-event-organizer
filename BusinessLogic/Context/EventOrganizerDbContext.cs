using Microsoft.EntityFrameworkCore;
using BusinessLogic.Entities;

namespace BusinessLogic.Context
{
    public class EventOrganizerDbContext : DbContext
    {
        public EventOrganizerDbContext() { }

        public EventOrganizerDbContext(DbContextOptions<EventOrganizerDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartsItems { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventCategory> EventCategories { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Event>().HasData(
                new Event
                {
                    Id = 1,
                    Name = "Event 1",
                    Date = DateTime.UtcNow,
                    Localization = "Local 1",
                    Description = "Description 1",
                    MaxCapacity = 100,
                    CategoryId = 1
                },
                new Event
                {
                    Id = 2,
                    Name = "Event 2",
                    Date = DateTime.UtcNow,
                    Localization = "Local 2",
                    Description = "Description 2",
                    MaxCapacity = 200,
                    CategoryId = 2
                }
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "Tiago Oliveira",
                },
                new User
                {
                    Id = 2,
                    Username = "Eduardo Gomes",
                }
            );

            modelBuilder.Entity<EventCategory>().HasData(
                new EventCategory
                {
                    Id = 1,
                    Name = "Games"
                },
                new EventCategory
                {
                    Id = 2,
                    Name = "Music"
                }
            );
            
            modelBuilder.Entity<Cart>().HasData(new Cart
            {
                Id = 1,
                UserId = 1

            });
            modelBuilder.Entity<Cart>().HasData(new Cart
            {
                Id = 2,
                UserId = 2

            });

        }
    }
}
