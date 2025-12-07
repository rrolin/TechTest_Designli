using System.ComponentModel.DataAnnotations;

namespace TechTest.ClientSide.Models
{
    /// <summary>
    /// Login View Model
    /// </summary>
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Username is required")]
        [MinLength(1, ErrorMessage = "Username cannot be empty.")]
        [MaxLength(50, ErrorMessage = "Username cannot be empty.")]
        public string? userName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter your password")]
        [MinLength(8, ErrorMessage = "Password too short.")]
        [MaxLength(50, ErrorMessage = "Password too long.")]
        public string? password { get; set; } = string.Empty;
    }
}