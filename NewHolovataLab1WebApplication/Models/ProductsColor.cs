using System;
using System.Collections.Generic;

namespace NewHolovataLab1WebApplication.Models;

public partial class ProductsColor
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int ColorId { get; set; }

    public int? Availability { get; set; }

    public virtual Color Color { get; set; }

    public virtual Product Product { get; set; }
}
