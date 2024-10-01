using System.Net.Http.Json;

namespace CarScrapyardWarehouse.Client.Interfaces;

public class HttpService : IHttpService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public HttpService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<T> Get<T>(string url)
    {
        var httpClient = _httpClientFactory.CreateClient("CarScrapyardWarehouse.ServerAPI");
        var response = await httpClient.GetAsync(url);
        if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
        {
            return default;
        }

        var result = await response.Content.ReadFromJsonAsync<T>();

        return result;
    }

    public async Task<HttpResponseMessage> Post(string url, object data)
    {
        var httpClient = _httpClientFactory.CreateClient("CarScrapyardWarehouse.ServerAPI");
        return await httpClient.PostAsJsonAsync(url, data);
    }

    public async Task<TResponse> Post<TResponse>(string url, object data)
    {
        var response = await Post(url, data);
        if (response == null) return default;
        return await response.Content.ReadFromJsonAsync<TResponse>();
    }

    public async Task<HttpResponseMessage> Post(string url, HttpContent data)
    {
        var httpClient = _httpClientFactory.CreateClient("CarScrapyardWarehouse.ServerAPI");
        var response = await httpClient.PostAsync(url, data);
        return response;
    }

    public async Task<TResponse> Post<TResponse>(string url, HttpContent data)
    {
        var response = await Post(url, data);
        if (response == null) return default;
        return await response.Content.ReadFromJsonAsync<TResponse>();
    }

    public async Task<HttpResponseMessage> Put(string url, object data)
    {
        var httpClient = _httpClientFactory.CreateClient("CarScrapyardWarehouse.ServerAPI");
        return await httpClient.PutAsJsonAsync(url, data);
    }

    public async Task<TResponse> Put<TResponse>(string url, object data)
    {
        var response = await Put(url, data);
        if (response == null) return default;
        return await response.Content.ReadFromJsonAsync<TResponse>();
    }

    public async Task<HttpResponseMessage> Delete(string url)
    {
        var httpClient = _httpClientFactory.CreateClient("CarScrapyardWarehouse.ServerAPI");
        return await httpClient.DeleteAsync(url);
    }

    public async Task<TResponse> Delete<TResponse>(string url)
    {
        var response = await Delete(url);
        if (response == null) return default;
        return await response.Content.ReadFromJsonAsync<TResponse>();
    }
}