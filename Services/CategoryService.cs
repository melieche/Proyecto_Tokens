using Proyecto_Tokens.Dto;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Proyecto_Tokens.Services;

public class CategoryService(IHttpClientFactory httpClientFactory)
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient("NodeApi");

    public async Task<List<CategoriaDto>> GetCategoriasAsync(string jwtToken = null)
    {
        if (!string.IsNullOrEmpty(jwtToken))
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);

        var response = await _httpClient.GetAsync("categorias");
        response.EnsureSuccessStatusCode();
        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<List<CategoriaDto>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }
    
    public async Task<CategoriaDto> GetCategoriaByIdAsync(int id, string jwtToken = null)
    {
        if (!string.IsNullOrEmpty(jwtToken))
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);

        var response = await _httpClient.GetAsync($"categorias/{id}");
        if (!response.IsSuccessStatusCode)
            return null;

        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<CategoriaDto>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }

    public async Task<CategoriaDto> CreateCategoriaAsync(CategoriaDto categoria, string jwtToken = null)
    {
        if (!string.IsNullOrEmpty(jwtToken))
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);

        var jsonContent = new StringContent(JsonSerializer.Serialize(categoria), System.Text.Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("categorias", jsonContent);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<CategoriaDto>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }

    public async Task<CategoriaDto> UpdateCategoriaAsync(int id, CategoriaDto categoria, string jwtToken = null)
    {
        if (!string.IsNullOrEmpty(jwtToken))
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);

        var jsonContent = new StringContent(JsonSerializer.Serialize(categoria), System.Text.Encoding.UTF8, "application/json");
        var response = await _httpClient.PutAsync($"categorias/{id}", jsonContent);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<CategoriaDto>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }

    public async Task<bool> DeleteCategoriaAsync(int id, string jwtToken = null)
    {
        if (!string.IsNullOrEmpty(jwtToken))
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);

        var response = await _httpClient.DeleteAsync($"categorias/{id}");
        return response.IsSuccessStatusCode;
    }
}

