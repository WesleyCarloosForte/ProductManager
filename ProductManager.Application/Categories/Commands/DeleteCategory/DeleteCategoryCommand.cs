using MediatR;
using ProductManager.Application.Common.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Application.Categories.Commands.DeleteCategory
{
    public record DeleteCategoryCommand(Guid id):IRequest<Result<bool>>;
    
}
