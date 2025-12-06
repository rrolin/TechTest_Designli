namespace TechTest.Infrastructure.Identity
{
    public class InMemoryAuthenticationService
    {
        private readonly Dictionary<string, string> _users = new()
        {
            { "testuser", "password123" },
            { "admin", "adminpass" }
        };

        public bool ValidateCredentials(string username, string password)
        {
            return _users.TryGetValue(username, out var storedPassword) &&
                   storedPassword == password;
        }
    }
}