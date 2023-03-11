using System;
using System.Collections.Generic;

namespace NewHolovataLab1WebApplication.Models;

public partial class OrderedProduct
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int OrderId { get; set; }

    public int Amount { get; set; }

    public int ColorId { get; set; }

    public virtual Color Color { get; set; }

    public virtual Order Order { get; set; }

    public virtual Product Product { get; set; }
}
