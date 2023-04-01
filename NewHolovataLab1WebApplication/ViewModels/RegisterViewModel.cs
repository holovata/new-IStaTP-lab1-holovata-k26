using System.ComponentModel.DataAnnotations;

namespace NewHolovataLab1WebApplication.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Ім'я")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Прізвище")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Адреса доставки")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Пароль")]    
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage ="Паролі не співпадають")]
        [Display(Name ="Підтвердження пароля")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
    }
}
