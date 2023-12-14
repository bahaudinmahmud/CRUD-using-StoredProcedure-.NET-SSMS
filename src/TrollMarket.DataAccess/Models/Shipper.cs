using System;
using System.Collections.Generic;

namespace TrollMarket.DataAccess.Models;

public partial class Shipper
{
    public int Id { get; set; }

    public string ShipperName { get; set; }

    public decimal Price { get; set; }

    public bool Service { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
