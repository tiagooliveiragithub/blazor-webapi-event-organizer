using Backend.Repositories.Contracts;
using BusinessLogic.Context;
using BusinessLogic.Dtos;
using BusinessLogic.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories;

public class ShoppingCartRepository(EventOrganizerDbContext eventOrganizerDbContext) : IShoppingCartRepository
{
    private async Task<bool> CartItemExists(int cartId, int eventId)
    {
        return await eventOrganizerDbContext.CartsItems.AnyAsync(c => c.CartId == cartId &&
                                                                      c.EventId == eventId);
    }
    
    public async Task<CartItem> AddItem(CartItemToAddDto cartItemToAddDto)
    {
        if (await CartItemExists(cartItemToAddDto.CartId, cartItemToAddDto.EventId) == false)
        {
            var item = await (from eve in eventOrganizerDbContext.Events
                where eve.Id == cartItemToAddDto.EventId
                select new CartItem
                {
                    CartId = cartItemToAddDto.CartId,
                    EventId = eve.Id,
                    Qty = cartItemToAddDto.Qty
                }).SingleOrDefaultAsync();

            if (item != null)
            {
                var result = await eventOrganizerDbContext.CartsItems.AddAsync(item);
                await eventOrganizerDbContext.SaveChangesAsync();
                return result.Entity;
            }
        }

        return null;

    }

    public async Task<CartItem> DeleteItem(int id)
    {
        var item = await eventOrganizerDbContext.CartsItems.FindAsync(id);

        if (item != null)
        {
            eventOrganizerDbContext.Remove(item);
            await eventOrganizerDbContext.SaveChangesAsync();
        }
            
        return item;

    }

    public async Task<CartItem?> GetItem(int id)
    {
        return await (from cart in eventOrganizerDbContext.Carts
            join cartItem in eventOrganizerDbContext.CartsItems
                on cart.Id equals cartItem.CartId
            where cartItem.Id == id
            select new CartItem
            {
                Id = cartItem.Id,
                EventId = cartItem.EventId,
                Qty = cartItem.Qty,
                CartId = cartItem.CartId
            }).SingleOrDefaultAsync();
    }

    public async Task<IEnumerable<CartItem>> GetItems(int userId)
    {
        return await (from cart in eventOrganizerDbContext.Carts
            join cardItem in eventOrganizerDbContext.CartsItems
                on cart.Id equals cardItem.CartId
            where cart.UserId == userId
            select new CartItem
            {
                Id = cardItem.Id,
                EventId = cardItem.EventId,
                Qty = cardItem.Qty,
                CartId = cardItem.CartId,
            }).ToListAsync();
    }
    
    public async Task<CartItem> UpdateQty(int id, CartItemQtyUpdateDto cartItemQtyUpdateDto)
    {
        var item = await eventOrganizerDbContext.CartsItems.FindAsync(id);

        if (item != null)
        {
            item.Qty = cartItemQtyUpdateDto.Qty;
            await eventOrganizerDbContext.SaveChangesAsync();
            return item;
        }

        return null;
    }
}