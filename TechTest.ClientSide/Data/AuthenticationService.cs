using System.Net.Http.Headers;

namespace TechTest.ClientSide.Data
{
    public class AuthenticationService
    {
        private readonly HttpClient _http;
        private readonly AuthenticationState _authState;

        public AuthenticationService(HttpClient http, AuthenticationState authState)
        {
            _http = http;
            _authState = authState;
        }

        public async Task<bool?> LoginAsync(string username, string password)
        {
            var response = await _http.PostAsJsonAsync("/api/auth/login", new { Username = username, Password = password });
            if (!response.IsSuccessStatusCode) return false;

            var result = await response.Content.ReadFromJsonAsync<LoginResponse>();
            if (result is null) return false;

            _authState.SetToken(result.Token); // store token

            return true;
        }
    }

    public class LoginResponse
    {
        public string Token { get; set; } = string.Empty;
    }
}