﻿using Domain.Entities.Commons;
using Domain.Entities.Products;

namespace Domain.Entities.Orders;

public class OrderDetail:BaseEntity
{
    public virtual Order Order { get; set; }
    public long OrderId { get; set; }

    public virtual Product Product { get; set; }
    public long ProductId { get; set; }

    public int Price { get; set; }
    public int Count { get; set; }
}
