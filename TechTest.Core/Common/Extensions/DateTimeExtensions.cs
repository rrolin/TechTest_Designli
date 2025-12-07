namespace TechTest.Core.Common.Extensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Returns a datetime with date part and shows like: "December 5, 2025".
        /// </summary>
        /// <param name="dateTime">DateTime value</param>
        /// <returns>Display date, if empty then returns empty string</returns>
        public static string ToDisplayDate(this DateTime? dateTime)
        {
            if (!dateTime.HasValue)
                return string.Empty;

            return dateTime.Value.ToString("MMMM d, yyyy");
        }
    }
}