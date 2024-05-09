using BusinessLogic.Dtos;
using Frontend.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace Frontend.Pages
{
    public class EventsBase : ComponentBase
    {
        [Inject]
        public IEventService EventService { get; set; }
        
        [Inject]
        public IShoppingCartService ShoppingCartService { get; set; }

        public IEnumerable<EventDto> Events { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Events = await EventService.GetEvents();

            var shoppingCartItems = await ShoppingCartService.GetItems(HardCoded.UserId);
            var totalQty = shoppingCartItems.Sum(i => i.Qty);
            
            ShoppingCartService.RaiseEventOnShoppingCartChanged(totalQty);
        }

        protected IOrderedEnumerable<IGrouping<int, EventDto>> GetGroupedEventsByCategory()
        {
            return from eve in Events
                   group eve by eve.CategoryId into categoryGroup
                   orderby categoryGroup.Key
                   select categoryGroup;
        }

        protected string GetCategoryName(IGrouping<int, EventDto> groupedEventsDtos)
        {
            return groupedEventsDtos.FirstOrDefault(eve => eve.CategoryId == groupedEventsDtos.Key)
                .CategoryName;
        }

    }
}
