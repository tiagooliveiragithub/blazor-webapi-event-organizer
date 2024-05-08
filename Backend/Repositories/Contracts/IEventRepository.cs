using BusinessLogic.Entities;
using EventOrganize.Models;

namespace Backend.Repositories.Contracts
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetEvents();
        Task<Event> GetEvent(int id);
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetCategory(int id);
        Task<IEnumerable<Ticket>> GetTickets(int eventId);
        

    }
}
