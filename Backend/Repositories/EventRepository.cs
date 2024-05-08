using BusinessLogic.Context;
using BusinessLogic.Entities;
using EventOrganize.Models;
using Microsoft.EntityFrameworkCore;
using Backend.Repositories.Contracts;

namespace Backend.Repositories
{
    public class EventRepository(EventOrganizerDbContext eventOrganizerDbContext) : IEventRepository
    {
        public async Task<IEnumerable<Category>> GetCategories()
        {
            var categories = await eventOrganizerDbContext.Categories.ToListAsync();

            return categories;
        }

        public Task<IEnumerable<Category>> GetCategory(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Event>> GetEvents()
        {
            var events = await eventOrganizerDbContext.Events.ToListAsync();

            return events;
        }

        public Task<IEnumerable<Ticket>> GetTickets(int eventId)
        {
            throw new NotImplementedException();
        }
    }
}
