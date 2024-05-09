using System.Net.Http.Json;
using BusinessLogic.Dtos;
using Frontend.Services.Contracts;

namespace Frontend.Services;

public class ShoppingCartService (HttpClient httpClient): IShoppingCartService
{
    public async Task<List<CartItemDto>> GetItems(int userId)
    {
        try
        {
            var response = await httpClient.GetAsync($"api/ShoppingCart/{userId}/GetItems");

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return Enumerable.Empty<CartItemDto>().ToList();
                }

                return await response.Content.ReadFromJsonAsync<List<CartItemDto>>();
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

    public async Task<CartItemDto> DeleteItem(int id)
    {
        try
        {
            var response = await httpClient.DeleteAsync($"api/ShoppingCart/{id}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<CartItemDto>();
            }
            return default(CartItemDto);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}