﻿using BusinessLogic.Dtos;
using Frontend.Services.Contracts;
using System.Net.Http.Json;

namespace Frontend.Services
{
    public class EventService : IEventService
    {
        private readonly HttpClient httpClient;

        public EventService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<EventDto>> GetEvents()
        {
            try
            {
                var events = await this.httpClient.GetFromJsonAsync<IEnumerable<EventDto>>("api/Event");
                return events;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
