using Backend.Repositories.Contracts;
using BusinessLogic.Dtos;
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
        
        [HttpGet("{id:int}")]
        public async Task<ActionResult<EventDto>> GetEvent(int id)
        {
            try
            {
                var eve = await this.eventRepository.GetEvent(id);

                if(eve == null)
                {
                    return BadRequest();
                }

                var eventCategory = await this.eventRepository.GetCategory(eve.CategoryId);
                var eventDto = eve.ConvertToDto(eventCategory);
                
                return Ok(eventDto);
                
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database.");
            }
            
        }


    }
}
