using BusinessLogic.Dtos;
using Frontend.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace Frontend.Pages;

public class ShoppingCartBase : ComponentBase
{
    [Inject]
    public IShoppingCartService ShoppingCartService { get; set; }
    public List<CartItemDto> ShoppingCartItems { get; set; }
    public string ErrorMessage { get; set; }
    
    protected override async Task OnInitializedAsync()
    {
        try
        {
            ShoppingCartItems = await ShoppingCartService.GetItems(HardCoded.UserId);
            
        }
        catch (Exception e)
        {
            ErrorMessage = e.Message;
        }
    }

    protected async Task DeleteCartItem_Click(int id)
    {
        var cartItemDto = await ShoppingCartService.DeleteItem(id);
        
        RemoveCartItem(id);
        
        
        
    }

    private CartItemDto GetCartItemDto(int id)
    {
        return ShoppingCartItems.FirstOrDefault(i => i.Id == id);
    }

    private void RemoveCartItem(int id)
    {
        var cartItemDto = GetCartItemDto(id);
        ShoppingCartItems.Remove(cartItemDto);
    }
}