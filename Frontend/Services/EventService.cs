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
                var response = await httpClient.GetAsync($"api/Event");
                
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<EventDto>();
                    }
                    return await response.Content.ReadFromJsonAsync<IEnumerable<EventDto>>();
                }

                var message = await response.Content.ReadAsStringAsync();
                throw new Exception(message);
            }
            catch (Exception)
            {
                //LOG Exception
                throw;
            }
        }

        public async Task<EventDto> GetEvent(int id)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/Event/{id}");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(EventDto);
                    }
                    return await response.Content.ReadFromJsonAsync<EventDto>();
                }

                var message = await response.Content.ReadAsStringAsync();
                throw new Exception(message);

            }
            catch (Exception)
            {
                //LOG Exception
                throw;
            }
        }
    }
}
