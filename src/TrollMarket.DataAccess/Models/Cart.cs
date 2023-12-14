using System;
using System.Collections.Generic;

namespace TrollMarket.DataAccess.Models;

public partial class Cart
{

    public int ProductId { get; set; }

    public int BuyerId { get; set; }

    public int ShipperId { get; set; }

    public int Quantity { get; set; }

    public virtual Buyer Buyer { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual Shipper Shipper { get; set; } = null!;
}
