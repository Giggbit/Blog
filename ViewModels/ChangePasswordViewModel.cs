using System.ComponentModel.DataAnnotations;

namespace Blog.ViewModels
{
    public class ChangePasswordViewModel
    {
        [Key]
        public string? Id { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Error Message")]
        public string? Email { get; set; }

        [Display(Name = "Old password")]
        [Required(ErrorMessage = "Ну указан старый пароль")]
        [DataType(DataType.Password)]
        public string? OldPassword { get; set; }

        [Display(Name = "New password")]
        [Required(ErrorMessage = "Не указан новый пароль")]
        [DataType(DataType.Password)]
        public string? NewPassword { get; set; }

        [MinLength(5, ErrorMessage = "Не менее 5 символов")]
        [Display(Name = "Повторитие пароль")]
        [Compare("NewPassword", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        public string? NewPasswordConfirm { get; set; }
    }
}
