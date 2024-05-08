using BusinessLogic.Entities;

namespace Backend.Repositories.Contracts
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetEvents();
        Task<Event> GetEvent(int id);
        Task<IEnumerable<EventCategory>> GetCategories();
        Task<EventCategory> GetCategory(int id);
    }
}
