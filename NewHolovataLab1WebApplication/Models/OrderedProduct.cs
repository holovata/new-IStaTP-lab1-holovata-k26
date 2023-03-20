using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewHolovataLab1WebApplication.Models;

public partial class OrderedProduct
{
    public int Id { get; set; }

    [Display(Name = "Товар")]
    [Required(ErrorMessage = "Поле не повинно бути пустим!")]
    public int ProductId { get; set; }

    [Display(Name = "Замовлення")]
    [Required(ErrorMessage = "Поле не повинно бути пустим!")]
    public int OrderId { get; set; }

    [Display(Name = "Кількість")]
    [Required(ErrorMessage = "Поле не повинно бути пустим!")]
    public int Amount { get; set; }

    [Display(Name = "Колір")]
    [Required(ErrorMessage = "Поле не повинно бути пустим!")]
    public int ColorId { get; set; }

    [Display(Name = "Кількість")]
    public virtual Color Color { get; set; }

    [Display(Name = "Замовлення")]
    public virtual Order Order { get; set; }

    [Display(Name = "Товар")]
    public virtual Product Product { get; set; }
}
