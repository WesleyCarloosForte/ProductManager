using MediatR;
using ProductManager.Application.Common.Response;
using ProductManager.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Application.Categories.Commands.CreateCategory
{
    public record CreateCategoryCommand(string name, EntityStatus Status = EntityStatus.Enabled):IRequest<Result<Guid>>;
}
