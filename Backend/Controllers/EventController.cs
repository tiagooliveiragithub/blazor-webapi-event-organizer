using BusinessLogic.Dtos;
using BusinessLogic.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventRepository eventRepository;

        public EventController(IEventRepository eventRepository)
        {
            this.eventRepository = eventRepository;            
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventDto>>> GetEvents()
        {
            try
            {
                var events = await this.eventRepository.GetEvents();
                var eventCategories = await this.eventRepository.GetCategories();

                if(events == null || eventCategories == null)
                {
                    return NotFound();
                }

                var eventDtos = events.ConvertToDto(eventCategories);
                return Ok(eventDtos);
                
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database.");
            }
            
        }


    }
}
