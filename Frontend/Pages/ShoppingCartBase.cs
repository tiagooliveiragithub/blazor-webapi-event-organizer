using BusinessLogic.Dtos;
using Frontend.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace Frontend.Pages;

public class ShoppingCartBase : ComponentBase
{
    [Inject]
    public IShoppingCartService ShoppingCartService { get; set; }
    public IEnumerable<CartItemDto> ShoppingCartItems { get; set; }
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
}