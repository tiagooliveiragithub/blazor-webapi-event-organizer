using BusinessLogic.Entities;
using EventOrganize.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Dtos
{
    public static class DtoConversions
    {
        public static IEnumerable<EventDto> ConvertToDto(this IEnumerable<Event> events,
                                                         IEnumerable<Category> eventCategories)
        {
            return (from eve in events
                    join eventCategory in eventCategories
                               on eve.CategoryId equals eventCategory.Id
                               select new EventDto
                               {
                                   Id = eve.Id,
                                   Name = eve.Name,
                                   Date = eve.Date,
                                   Hour = eve.Hour,
                                   Localization = eve.Localization,
                                   Description = eve.Description,
                                   MaxCapacity = eve.MaxCapacity,
                                   OwnerId = eve.OwnerId,
                                   CategoryId = eve.CategoryId,
                                   CategoryName = eventCategory.Name
                               }).ToList();
        }
    }
}
