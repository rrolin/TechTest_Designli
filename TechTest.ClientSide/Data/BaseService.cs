using System.Net.Http.Headers;

namespace TechTest.ClientSide.Data
{
    public abstract class BaseService
    {
        protected readonly HttpClient _http;
        private readonly AuthenticationState _authenticationState;

        protected BaseService(IHttpClientFactory factory, AuthenticationState authenticationState)
        {
            _http = factory.CreateClient("TechTestApi");
            _authenticationState = authenticationState;
        }

        protected async Task<T?> GetAsync<T>(string url)
        {
            AttachToken();
            return await _http.GetFromJsonAsync<T>(url);
        }

        protected async Task<T?> PostAsync<T>(string url, object data)
        {
            var response = await _http.PostAsJsonAsync(url, data);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>();
        }

        private void AttachToken()
        {
            if (!string.IsNullOrEmpty(_authenticationState.jwtToken))
            {
                _http.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", _authenticationState.jwtToken);
            }
        }
    }
}