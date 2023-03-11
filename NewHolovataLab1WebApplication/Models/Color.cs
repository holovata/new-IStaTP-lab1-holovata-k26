using System;
using System.Collections.Generic;

namespace NewHolovataLab1WebApplication.Models;

public partial class Color
{
    public int Id { get; set; }

    public string Code { get; set; }

    public string Name { get; set; }

    public virtual ICollection<OrderedProduct> OrderedProducts { get; } = new List<OrderedProduct>();

    public virtual ICollection<ProductsColor> ProductsColors { get; } = new List<ProductsColor>();
}
