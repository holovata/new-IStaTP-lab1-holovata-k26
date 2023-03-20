using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewHolovataLab1WebApplication.Models;

public partial class Order
{
    public int Id { get; set; }

    [Display(Name = "Користувач")]
    [Required(ErrorMessage = "Поле не повинно бути пустим!")]
    public int UserId { get; set; }

    [Display(Name = "Магазин")]
    [Required(ErrorMessage = "Поле не повинно бути пустим!")]
    public int ShopId { get; set; }

    [Display(Name = "Час замовлення")]
    [Required(ErrorMessage = "Поле не повинно бути пустим!")]
    public DateTime Time { get; set; }

    public virtual ICollection<OrderedProduct> OrderedProducts { get; } = new List<OrderedProduct>();

    [Display(Name = "Магазин")]
    public virtual Shop Shop { get; set; }

    [Display(Name = "Користувач")]
    public virtual User User { get; set; }
}
