using Backend.Repositories.Contracts;
using BusinessLogic.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ShoppingCartController(
    IShoppingCartRepository shoppingCartRepository,
    IEventRepository eventRepository
    ) : ControllerBase
{
    [HttpGet]
    [Route("{userId}/GetItems")]
    public async Task<ActionResult<IEnumerable<CartItemDto>>> GetItems(int userId)
    {
        try
        {
            var cartItems = await shoppingCartRepository.GetItems(userId);

            if (cartItems == null)
            {
                return NoContent();
            }
            

            var events = await eventRepository.GetEvents();

            if (events == null)
            {
                throw new Exception("No events exist in the system");
            }

            var cartItemsDto = cartItems.ConvertToDto(events);

            return Ok(cartItemsDto);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<CartItemDto>> GetItem(int id)
    {
        try
        {
            var cartItem = await shoppingCartRepository.GetItem(id);
            if (cartItem == null)
            {
                return NotFound();
            }
            var eve = await eventRepository.GetEvent(cartItem.EventId);
            if (eve == null)
            {
                return NotFound();
            }
            var cartItemDto = cartItem.ConvertToDto(eve);
            return Ok(cartItemDto);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }
    
    [HttpPost]
    public async Task<ActionResult<CartItemDto>> PostItem([FromBody] CartItemToAddDto cartItemToAddDto)
    {
        try
        {
            var newCartItem = await shoppingCartRepository.AddItem(cartItemToAddDto);
            if (newCartItem == null)
            {
                return NoContent();
            }
            var eve = await eventRepository.GetEvent(newCartItem.EventId);
            if (eve == null)
            {
                throw new Exception($"Something went wrong when attempting to retrieve event (eventId: {cartItemToAddDto.EventId}");
            }
            
            var newCartItemDto = newCartItem.ConvertToDto(eve);

            return CreatedAtAction(nameof(GetItem), new { id = newCartItemDto.Id }, newCartItemDto);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }
    
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<CartItemDto>> DeleteItem(int id)
    {
        try
        {
            var cartItem = await shoppingCartRepository.DeleteItem(id);
                
            if (cartItem == null)
            { 
                return NotFound();
            }

            var eve = await eventRepository.GetEvent(cartItem.EventId);

            if (eve == null)
                return NotFound();

            var cartItemDto = cartItem.ConvertToDto(eve);

            return Ok(cartItemDto);

        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }
}