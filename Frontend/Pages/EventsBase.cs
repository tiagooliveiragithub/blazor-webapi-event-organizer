using BusinessLogic.Dtos;
using Frontend.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace Frontend.Pages
{
    public class EventsBase : ComponentBase
    {
        [Inject]
        public IEventService EventService { get; set; }

        public IEnumerable<EventDto> Events { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Events = await EventService.GetEvents();
        }

    }
}
