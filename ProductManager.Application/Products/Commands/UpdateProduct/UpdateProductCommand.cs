using MediatR;
using ProductManager.Application.Common.Response;
using ProductManager.Application.DTO;
using ProductManager.Domain.Common;
using ProductManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Application.Products.Commands.UpdateProduct
{
    public record UpdateProductCommand(Guid id,Guid categoryId,decimal price,string name,EntityStatus Status,bool inStock):IRequest<Result<ProductDTO>>;
  
}
