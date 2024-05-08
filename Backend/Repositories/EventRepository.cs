using BusinessLogic.Context;
using BusinessLogic.Entities;
using EventOrganize.Models;
using Microsoft.EntityFrameworkCore;
using Backend.Repositories.Contracts;

namespace Backend.Repositories
{
    public class EventRepository(EventOrganizerDbContext eventOrganizerDbContext) : IEventRepository
    {
        
        public async Task<IEnumerable<Event>> GetEvents()
        {
            var events = await eventOrganizerDbContext.Events.ToListAsync();

            return events;
        }
        
        public async Task<Event> GetEvent(int id)
        {
            var eve = await eventOrganizerDbContext.Events.FindAsync(id);
            return eve;
        }
        
        public async Task<IEnumerable<Category>> GetCategories()
        {
            var categories = await eventOrganizerDbContext.Categories.ToListAsync();

            return categories;
        }

        public async Task<Category> GetCategory(int id)
        {
            var category = await eventOrganizerDbContext.Categories.FindAsync(id);
            return category;
        }

        public Task<IEnumerable<Ticket>> GetTickets(int eventId)
        {
            throw new NotImplementedException();
        }
    }
}
