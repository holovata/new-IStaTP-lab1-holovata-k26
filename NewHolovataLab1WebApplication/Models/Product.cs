using System;
using System.Collections.Generic;

namespace NewHolovataLab1WebApplication.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; }

    public decimal Price { get; set; }

    public int TypeId { get; set; }

    public virtual ICollection<OrderedProduct> OrderedProducts { get; } = new List<OrderedProduct>();

    public virtual ICollection<ProductsColor> ProductsColors { get; } = new List<ProductsColor>();

    public virtual ProductType Type { get; set; }
}
