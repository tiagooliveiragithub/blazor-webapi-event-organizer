using BusinessLogic.Context;
using BusinessLogic.Entities;
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
        
        public async Task<IEnumerable<EventCategory>> GetCategories()
        {
            var categories = await eventOrganizerDbContext.EventCategories.ToListAsync();

            return categories;
        }

        public async Task<EventCategory> GetCategory(int id)
        {
            var category = await eventOrganizerDbContext.EventCategories.FindAsync(id);
            return category;
        }
    }
}
