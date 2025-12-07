namespace TechTest.ClientSide.Data
{
    /// <summary>
    /// Authentication service to handle user login and token management.
    /// </summary>
    public class AuthenticationService
    {
        private readonly HttpClient _http;
        private readonly AuthenticationState _authenticationState;

        public AuthenticationService(IHttpClientFactory factory, AuthenticationState authenticationState)
        {
            _http = factory.CreateClient("TechTestApi");
            _authenticationState = authenticationState;
        }

        /// <summary>
        /// Login user with provided credentials.
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <returns>Bool indicating result of the request.</returns>
        public async Task<bool?> LoginAsync(string username, string password)
        {
            var response = await _http.PostAsJsonAsync("/api/Authentication/login", new { Username = username, Password = password });
            if (!response.IsSuccessStatusCode) return false;

            var result = await response.Content.ReadFromJsonAsync<LoginResponse>();
            if (result is null) return false;

            _authenticationState.SetToken(result.Token);

            return true;
        }
    }

    public class LoginResponse
    {
        public string Token { get; set; } = string.Empty;
    }
}