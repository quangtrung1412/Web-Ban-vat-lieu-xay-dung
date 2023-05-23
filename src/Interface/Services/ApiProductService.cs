using System.Text.Json;
using App.Shared.Entities;
using App.Shared.RetryPolicy;
using Polly.Retry;

namespace App.Interface.Services;

public class ApiProductService : IApiProductService
{
    private readonly string _productApiUrl;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly AsyncRetryPolicy _retryPolicy;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public ApiProductService(IHttpClientFactory httpClientFactory, IRetryPolicyFactory retryPolicyFactory, IConfiguration configuration)
    {
        var configProductApi = configuration["ApiProduct"];
        var formatedApiUri = configProductApi.EndsWith("/") ? configProductApi.Substring(0, configProductApi.Length - 1) : configProductApi;
        _productApiUrl = $"{formatedApiUri}";
        _httpClientFactory = httpClientFactory;
        _retryPolicy = retryPolicyFactory.CreateAsyncRetryPolicy<Exception>(5, nameof(ApiProductService));
        _jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
    }
    public async Task<IEnumerable<Product>> GetListProduct(string search, int page)
    {
        var apiUri = string.IsNullOrEmpty(search) ? _productApiUrl : $"{_productApiUrl}&search={search}&page={page}";
        return await _retryPolicy.ExecuteAsync(async () =>
        {
            using (var httpClient = _httpClientFactory.CreateClient())
            {
                var responseString = await httpClient.GetStringAsync(apiUri);
                if (!string.IsNullOrEmpty(responseString))
                {
                    var response = JsonSerializer.Deserialize<IEnumerable<Product>>(responseString, _jsonSerializerOptions);

                    return response;
                }
            }
        });
        throw Exception("sadads");
    }
}