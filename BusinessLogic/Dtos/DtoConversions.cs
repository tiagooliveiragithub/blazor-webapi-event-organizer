using BusinessLogic.Entities;

namespace BusinessLogic.Dtos
{
    public static class DtoConversions
    {
        public static IEnumerable<EventDto> ConvertToDto(this IEnumerable<Event> events,
                                                         IEnumerable<EventCategory> eventCategories)
        {
            return (from eve in events
                    join eventCategory in eventCategories
                               on eve.CategoryId equals eventCategory.Id
                               select new EventDto
                               {
                                   Id = eve.Id,
                                   Name = eve.Name,
                                   Date = eve.Date,
                                   Price = eve.Price,
                                   Localization = eve.Localization,
                                   Description = eve.Description,
                                   MaxCapacity = eve.MaxCapacity,
                                   CategoryId = eve.CategoryId,
                                   CategoryName = eventCategory.Name
                               }).ToList();
        }
        
        
        public static EventDto ConvertToDto(this Event eve,
            EventCategory category)
        {
            return new EventDto
            {
                Id = eve.Id,
                Name = eve.Name,
                Date = eve.Date,
                Price = eve.Price,
                Localization = eve.Localization,
                Description = eve.Description,
                MaxCapacity = eve.MaxCapacity,
                CategoryId = eve.CategoryId,
                CategoryName = category.Name
            };
        }

        public static IEnumerable<CartItemDto> ConvertToDto(this IEnumerable<CartItem> cartItems,
                                                                IEnumerable<Event> events)
        {
            return (from cartItem in cartItems
                join eve in events
                    on cartItem.EventId equals eve.Id
                select new CartItemDto
                {
                    Id = cartItem.Id,
                    EventId = cartItem.EventId,
                    EventName = eve.Name,
                    EventDescription = eve.Description,
                    Price = eve.Price,
                    CartId = cartItem.CartId,
                    Qty = cartItem.Qty,
                    TotalPrice = eve.Price * cartItem.Qty
                }).ToList();
        }
        
        public static CartItemDto ConvertToDto(this CartItem cartItem,
            Event eve)
        {
            return new CartItemDto
            {
                Id = cartItem.Id,
                EventId = cartItem.EventId,
                EventName = eve.Name,
                EventDescription = eve.Description,
                Price = eve.Price,
                CartId = cartItem.CartId,
                Qty = cartItem.Qty,
                TotalPrice = eve.Price * cartItem.Qty
            };
        }
    }
}
