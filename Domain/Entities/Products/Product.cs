﻿using Domain.Entities.Products;
using Domain.Entities.Commons;
using Domain.Entities.Orders;
using Domain.Entities.Carts;
namespace Domain.Entities.Products;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public string Brand { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public int Inventory { get; set; }
    public bool Displayed { get; set; }
    public int ViewCount { get; set; }
    public virtual Category Category { get; set; }
    public long CategoryId { get; set; }
    public virtual ICollection<ProductImages> ProductImages { get; set; }
    public virtual ICollection<ProductFeatures> ProductFeatures { get; set; }
    public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    public virtual ICollection<CartItem> CartItems { get; set; }

}
