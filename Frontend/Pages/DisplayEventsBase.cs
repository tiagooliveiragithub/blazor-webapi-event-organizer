using BusinessLogic.Dtos;
using Microsoft.AspNetCore.Components;

namespace Frontend.Pages
{
    public class DisplayEventsBase : ComponentBase
    {
        [Parameter]
        public IEnumerable<EventDto> Events { get; set; }
    }
}
