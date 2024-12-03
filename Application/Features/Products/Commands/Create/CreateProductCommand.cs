using Application.Common.Interfaces;
using Application.Dtos.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Application.Features.Products.Commands.Create;

public class CreateProductCommand: ITransactionRequest
{
    public string Title { get; set; }
    public decimal Price { get; set; }
    public int Count { get; set; }
    public string Description { get; set; }
}
