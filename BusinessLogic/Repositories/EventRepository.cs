using BusinessLogic.Context;
using BusinessLogic.Entities;
using BusinessLogic.Repositories.Contracts;
using EventOrganize.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly EventOrganizerDbContext eventOrganizerDbContext;

        public EventRepository(EventOrganizerDbContext eventOrganizerDbContext)
        {
            this.eventOrganizerDbContext = eventOrganizerDbContext;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            var categories = await this.eventOrganizerDbContext.Categories.ToListAsync();

            return categories;
        }

        public Task<IEnumerable<Category>> GetCategory(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Event>> GetEvents()
        {
            var events = await this.eventOrganizerDbContext.Events.ToListAsync();

            return events;
        }

        public Task<IEnumerable<Ticket>> GetTickets(int eventId)
        {
            throw new NotImplementedException();
        }
    }
}
