using MediatR;
using ProductManager.Application.Common.Response;
using ProductManager.Domain.Common;
using ProductManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Application.Products.Commands.CreateProduct
{
   public record CreateProductCommand(string Name, Guid CategoryId, decimal Price, bool inStock = true, EntityStatus Status = EntityStatus.Enabled) : IRequest<Result<Guid>>;

}
