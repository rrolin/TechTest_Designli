namespace TechTest.Infrastructure.Identity
{
    public class InMemoryAuthenticationService
    {
        private readonly Dictionary<string, string> _users = new()
        {
            { "cnorris", "ChuckNorris" },
        };

        public bool ValidateCredentials(string username, string password)
        {
            return _users.TryGetValue(username, out var storedPassword) &&
                   storedPassword == password;
        }
    }
}