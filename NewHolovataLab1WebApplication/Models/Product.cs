using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewHolovataLab1WebApplication.Models;

public partial class Product
{
    public int Id { get; set; }

    [Display(Name = "Назва")]
    [Required(ErrorMessage = "Поле не повинно бути пустим!")]
    public string Name { get; set; }

    [Display(Name = "Ціна")]
    [Required(ErrorMessage = "Поле не повинно бути пустим!")]
    public decimal Price { get; set; }

    [Display(Name = "Тип")]
    [Required(ErrorMessage = "Поле не повинно бути пустим!")]
    public int TypeId { get; set; }

    public virtual ICollection<OrderedProduct> OrderedProducts { get; } = new List<OrderedProduct>();

    public virtual ICollection<ProductsColor> ProductsColors { get; } = new List<ProductsColor>();

    [Display(Name = "Тип")]
    public virtual ProductType Type { get; set; }
}
