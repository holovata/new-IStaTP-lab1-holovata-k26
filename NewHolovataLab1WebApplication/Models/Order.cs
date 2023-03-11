using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewHolovataLab1WebApplication.Models;

public partial class Order
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int ShopId { get; set; }

    public DateTime Time { get; set; }

    public virtual ICollection<OrderedProduct> OrderedProducts { get; } = new List<OrderedProduct>();

    public virtual Shop Shop { get; set; }

    public virtual User User { get; set; }
}
