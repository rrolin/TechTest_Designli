namespace TechTest.Core.Application.DTO
{
    public class EmployeeDto
    {
        public int? EmployeeId { get; set; }
        public string? FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;
        public DateTime? Birthdate { get; set; } = DateTime.Now.AddYears(-65);
        public DateTime? EnteredDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; } = DateTime.Now;
        public List<string> Errors { get; set; } = new List<string>();
    }
}