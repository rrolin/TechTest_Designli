namespace TechTest.Infrastructure.Identity
{
    /// <summary>
    /// In memory data store for user authentication
    /// </summary>
    public class InMemoryAuthenticationService
    {
        private readonly Dictionary<string, string> _users = new()
        {
            { "user", "password" },
        };

        /// <summary>
        /// Validate provided credentials against in-memory store user data
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <returns>Result of the validation</returns>
        public bool ValidateCredentials(string username, string password)
        {
            return _users
                .TryGetValue(username, out var storedPassword) && storedPassword == password;
        }
    }
}