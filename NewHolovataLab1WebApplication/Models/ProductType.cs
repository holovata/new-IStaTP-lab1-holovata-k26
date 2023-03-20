using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewHolovataLab1WebApplication.Models;

public partial class ProductType
{
    public int Id { get; set; }

    [Display(Name = "Назва")]
    [Required(ErrorMessage = "Поле не повинно бути пустим!")]
    public string Name { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
