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
            var item = await (from product in eventOrganizerDbContext.Events
                where product.Id == cartItemToAddDto.EventId
                select new CartItem
                {
                    CartId = cartItemToAddDto.CartId,
                    EventId = product.Id,
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

    public Task<CartItem> UpdateQty(int id, CartItemQtyUpdateDto cartItemQtyUpdateDto)
    {
        throw new NotImplementedException();
    }

    public Task<CartItem> DeleteItem(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<CartItem> GetItem(int id)
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
}