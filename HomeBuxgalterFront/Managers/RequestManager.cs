using System.Net.Http.Json;
using static System.Net.WebRequestMethods;



namespace HomeBuxgalterFront.Managers;

public class RequestManager
{
    public HttpClient _httpClient;

    public RequestManager(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<T?> Get<T>(string url)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, url);

        var response = await _httpClient.SendAsync(request);

        T? model = await response.Content.ReadFromJsonAsync<T>();

        return model;
    }

    public async Task<T?> Post<T>(string url)
    {
        return default;
    }
}
