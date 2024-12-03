﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Product
{
    public int Id { get; set; }
    public string Title { get; set; }
    public decimal Price { get; set; }
    public int Count { get; set; }
    public string Description { get; set; }


    public virtual ICollection<OrderDetail> OrderDetails { get; set; }
}
