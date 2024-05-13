using System.ComponentModel.DataAnnotations;

namespace Blog.ViewModels
{
    public class RegisterUserViewModel
    {
        [Required(ErrorMessage = "Не указано Имя")]
        [Display(Name = "Name")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "No Email")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Phone must have")]
        [Display(Name = "Phone")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "Password must have")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [MinLength(5, ErrorMessage = "Password must be no less then 5")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Password must have")]
        [Compare("Password", ErrorMessage = "Passwords ...")]
        [Display(Name = "Confirm password")]
        [DataType(DataType.Password)]
        public string? PasswordConfirm { get; set; }

        public string? Code { get; set; }

    }
}
