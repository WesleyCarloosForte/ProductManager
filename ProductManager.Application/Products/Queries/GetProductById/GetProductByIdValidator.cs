using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Application.Products.Queries.GetProductById
{
    public class GetProductByIdValidator:AbstractValidator<GetProductByIdQuery>
    {
        public GetProductByIdValidator() 
        {
            RuleFor(x => x.id)
                    .NotEmpty()
                    .WithMessage("Invalid parameter Id");
        }

    }
}
