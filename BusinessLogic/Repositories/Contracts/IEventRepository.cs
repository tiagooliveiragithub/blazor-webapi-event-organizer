using BusinessLogic.Entities;
using EventOrganize.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Repositories.Contracts
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetEvents();
        Task<IEnumerable<Category>> GetCategories();
        Task<IEnumerable<Ticket>> GetTickets(int eventId);
        Task<IEnumerable<Category>> GetCategory(int id);

    }
}
