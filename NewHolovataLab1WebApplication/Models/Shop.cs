using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewHolovataLab1WebApplication.Models;

public partial class Shop
{
    public int Id { get; set; }

    [Display(Name = "Адреса")]
    [Required(ErrorMessage = "Поле не повинно бути пустим!")]
    public string Address { get; set; }

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
