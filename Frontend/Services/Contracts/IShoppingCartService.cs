﻿using BusinessLogic.Dtos;

namespace Frontend.Services.Contracts;

public interface IShoppingCartService
{
    Task<IEnumerable<CartItemDto>> GetItems(int userId);
    Task<CartItemDto> AddItem(CartItemToAddDto cartItemToAddDto);
}