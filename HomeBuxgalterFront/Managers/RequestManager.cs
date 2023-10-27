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

    public async Task<T?> Get<T>()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "/api/profits");

        var response = await _httpClient.SendAsync(request);

        var model = await response.Content.ReadFromJsonAsync<T?>();

        return model;
    }
}
