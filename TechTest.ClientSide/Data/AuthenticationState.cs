namespace TechTest.ClientSide.Data
{
    public class AuthenticationState
    {
        public string? jwtToken { get; private set; }

        public void SetToken(string token) => jwtToken = token;
        public void ClearToken() => jwtToken = null;
    }
}