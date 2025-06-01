using Proyecto_Tokens.Dto;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Proyecto_Tokens.Services;
public class ProductoService(IHttpClientFactory httpClientFactory)
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient("NodeApi");

    public async Task<List<ProductoDto>> GetProductosAsync(string jwtToken = null)
    {
        if (!string.IsNullOrEmpty(jwtToken))
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);

        var response = await _httpClient.GetAsync("productos");
        response.EnsureSuccessStatusCode();
        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<List<ProductoDto>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }

    public async Task<ProductoDto> GetProductoByIdAsync(int id, string jwtToken = null)
    {
        if (!string.IsNullOrEmpty(jwtToken))
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);

        var response = await _httpClient.GetAsync($"productos/{id}");
        if (!response.IsSuccessStatusCode)
            return null;

        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<ProductoDto>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }

    public async Task<ProductoDto> CreateProductoAsync(ProductoDto producto, string jwtToken = null)
    {
        if (!string.IsNullOrEmpty(jwtToken))
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);

        var response = await _httpClient.PostAsJsonAsync("productos", producto);
        response.EnsureSuccessStatusCode();
        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<ProductoDto>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }
    
    public async Task<ProductoDto> UpdateProductoAsync(int id, ProductoDto producto, string jwtToken = null)
    {
        if (!string.IsNullOrEmpty(jwtToken))
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);

        var response = await _httpClient.PutAsJsonAsync($"productos/{id}", producto);
        response.EnsureSuccessStatusCode();
        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<ProductoDto>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }
    
    public async Task<bool> DeleteProductoAsync(int id, string jwtToken = null)
    {
        if (!string.IsNullOrEmpty(jwtToken))
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);

        var response = await _httpClient.DeleteAsync($"productos/{id}");
        return response.IsSuccessStatusCode;
    }
}

