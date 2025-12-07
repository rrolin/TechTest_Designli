using System.Net.Http.Headers;

namespace TechTest.ClientSide.Data
{
    /// <summary>
    /// Base service for authenticated API calls.
    /// </summary>
    public abstract class BaseService
    {
        protected readonly HttpClient _http;
        private readonly AuthenticationState _authenticationState;

        protected BaseService(IHttpClientFactory factory, AuthenticationState authenticationState)
        {
            _http = factory.CreateClient("TechTestApi");
            _authenticationState = authenticationState;
        }

        /// <summary>
        /// Generic GET method with JWT token attachment.
        /// </summary>
        /// <typeparam name="T">Type of</typeparam>
        /// <param name="url">Http Request Url</param>
        /// <returns></returns>
        protected async Task<T?> GetAsync<T>(string url)
        {
            AttachToken();
            return await _http.GetFromJsonAsync<T>(url);
        }

        /// <summary>
        /// Attach session JWT token to request headers.
        /// </summary>
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