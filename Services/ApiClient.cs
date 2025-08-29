using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace TaskC.Services
{
    public class ApiClient : IApiClient
    {
        private readonly HttpClient _http;
        public ApiClient(HttpClient http) => _http = http;

        public Task<HttpResponseMessage> PostJsonAsync<T>(string relativeUrl, T body, CancellationToken ct = default)
        => _http.PostAsJsonAsync(relativeUrl, body, ct);
    }
}
