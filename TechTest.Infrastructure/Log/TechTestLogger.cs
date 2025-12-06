namespace TechTest.Infrastructure.Log
{
    public class TechTestLogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"[LOG] {DateTime.Now}: {message}");
        }
    }
}