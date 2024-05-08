using System.Net.Http.Json;
using BusinessLogic.Dtos;
using Frontend.Services.Contracts;

namespace Frontend.Services;

public class ShoppingCartService (HttpClient httpClient): IShoppingCartService
{
    public async Task<IEnumerable<CartItemDto>> GetItems(int userId)
    {
        try
        {
            var response = await httpClient.GetAsync($"api/ShoppingCart/{userId}/GetItems");

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return Enumerable.Empty<CartItemDto>();
                }

                return await response.Content.ReadFromJsonAsync<IEnumerable<CartItemDto>>();
            }

            var message = await response.Content.ReadAsStringAsync();
            throw new Exception($"Http Status: {response.StatusCode} Message {message}");

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<CartItemDto> AddItem(CartItemToAddDto cartItemToAddDto)
    {
        try
        {
            var response = await httpClient.PostAsJsonAsync<CartItemToAddDto>("api/ShoppingCart", cartItemToAddDto);

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return default(CartItemDto);
                }

                return await response.Content.ReadFromJsonAsync<CartItemDto>();
            }

            var message = await response.Content.ReadAsStringAsync();
            throw new Exception($"Http Status: {response.StatusCode} Message {message}");

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}