using BusinessLogic.Dtos;
using Frontend.Services.Contracts;
using System.Net.Http.Json;

namespace Frontend.Services
{
    public class EventService(HttpClient httpClient) : IEventService
    {
        public async Task<IEnumerable<EventDto>> GetEvents()
        {
            try
            {
                var events = await httpClient.GetFromJsonAsync<IEnumerable<EventDto>>("api/Event");
                return events;
            }
            catch (Exception)
            {
                throw new KeyNotFoundException();
            }
        }
    }
}
