using System.ComponentModel.DataAnnotations;

namespace HttpHost.Domain.Dto
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "First Name is required")]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [MaxLength(60)]
        public string LastName { get; set; }

        [MaxLength(30)]
        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [MaxLength(70)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [MaxLength(40)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [MaxLength(40)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
