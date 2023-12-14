using System;
using System.Collections.Generic;

namespace TrollMarket.DataAccess.Models;

public partial class Product
{
    public int Id { get; set; }

    public string ProductName { get; set; } = null!;

    public string Category { get; set; } = null!;

    public decimal Price { get; set; }

    public string? Description { get; set; }

    public bool Discontinue { get; set; }

    public int SellerId { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Seller Seller { get; set; } = null!;
}
