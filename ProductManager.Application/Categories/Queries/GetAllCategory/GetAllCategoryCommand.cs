using MediatR;
using ProductManager.Application.Common.Response;
using ProductManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Application.Categories.Queries.GetAllCategory
{
    public record GetAllCategoryCommand():IRequest<Result<IEnumerable<Category>>>;

}
