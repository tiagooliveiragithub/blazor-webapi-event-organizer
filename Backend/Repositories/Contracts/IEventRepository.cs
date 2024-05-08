using BusinessLogic.Entities;
using EventOrganize.Models;

namespace Backend.Repositories.Contracts
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetEvents();
        Task<IEnumerable<Category>> GetCategories();
        Task<IEnumerable<Ticket>> GetTickets(int eventId);
        Task<IEnumerable<Category>> GetCategory(int id);

    }
}
