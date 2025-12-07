namespace TechTest.ClientSide.Data
{
    /// <summary>
    /// Dummy class for handling authentication client side from memory
    /// </summary>
    public class AuthenticationState
    {
        public string? jwtToken { get; private set; }
        public void SetToken(string token) => jwtToken = token;
        public void ClearToken() => jwtToken = null;
    }
}