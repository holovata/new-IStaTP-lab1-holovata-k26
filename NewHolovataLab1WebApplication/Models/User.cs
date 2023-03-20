using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewHolovataLab1WebApplication.Models;

public partial class User
{
    public int Id { get; set; }

    [Display(Name = "Email")]
    [Required(ErrorMessage = "Поле не повинно бути пустим!")]
    public string Email { get; set; }

    [Display(Name = "Ім'я")]
    [Required(ErrorMessage = "Поле не повинно бути пустим!")]
    public string Name { get; set; }

    [Display(Name = "Прізвище")]
    [Required(ErrorMessage = "Поле не повинно бути пустим!")]
    public string LastName { get; set; }

    [Display(Name = "Адреса доставки")]
    [Required(ErrorMessage = "Поле не повинно бути пустим!")]
    public string Address { get; set; }

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
