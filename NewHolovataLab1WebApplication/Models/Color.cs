using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewHolovataLab1WebApplication.Models;

public partial class Color
{
    public int Id { get; set; }

    [Display(Name = "Код")]
    [Required(ErrorMessage ="Поле не повинно бути пустим!")]
    public string Code { get; set; }

    [Display(Name = "Назва")]
    [Required(ErrorMessage = "Поле не повинно бути пустим!")]
    public string Name { get; set; }

    public virtual ICollection<OrderedProduct> OrderedProducts { get; } = new List<OrderedProduct>();

    public virtual ICollection<ProductsColor> ProductsColors { get; } = new List<ProductsColor>();
}
