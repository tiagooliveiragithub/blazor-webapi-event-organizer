using BusinessLogic.Dtos;

namespace Frontend.Services.Contracts
{
    public interface IEventService
    {
        Task<IEnumerable<EventDto>> GetEvents();
    }
}
