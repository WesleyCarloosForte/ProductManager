using MediatR;
using ProductManager.Application.Common.Response;
using ProductManager.Domain.Common;
using ProductManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Application.Categories.Commands.UpdateCategory
{
    public record UpdateCategoryCommand(Guid id,string name):IRequest<Result<Category>>;

}
