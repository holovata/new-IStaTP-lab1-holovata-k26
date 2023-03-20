using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewHolovataLab1WebApplication.Models;

public partial class ProductsColor
{
    public int Id { get; set; }

    [Display(Name = "Товар")]
    [Required(ErrorMessage = "Поле не повинно бути пустим!")]
    public int ProductId { get; set; }

    [Display(Name = "Колір")]
    [Required(ErrorMessage = "Поле не повинно бути пустим!")]
    public int ColorId { get; set; }

    [Display(Name = "Доступність (0/1)")]
    [Required(ErrorMessage = "Поле не повинно бути пустим!")]
    public int? Availability { get; set; }

    [Display(Name = "Колір")]
    public virtual Color Color { get; set; }

    [Display(Name = "Товар")]
    public virtual Product Product { get; set; }
}
