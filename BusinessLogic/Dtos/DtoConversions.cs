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
                Localization = eve.Localization,
                Description = eve.Description,
                MaxCapacity = eve.MaxCapacity,
                CategoryId = eve.CategoryId,
                CategoryName = category.Name
            };
        }
    }
}
