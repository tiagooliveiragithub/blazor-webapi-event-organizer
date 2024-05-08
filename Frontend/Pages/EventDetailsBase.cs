using BusinessLogic.Dtos;
using Frontend.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace Frontend.Pages;

public class EventDetailsBase : ComponentBase
{
    [Parameter]
    public int Id { get; set; }
    
    [Inject]
    public IEventService EventService { get; set; }
    
    public EventDto Event { get; set; }
    
    public string ErrorMessage { get; set; }

    protected override async Task OnInitializedAsync()
    {
        try
        {
            Event = await EventService.GetEvent(Id);
        }
        catch (Exception e)
        {
            ErrorMessage = e.Message;
        }
    }
}