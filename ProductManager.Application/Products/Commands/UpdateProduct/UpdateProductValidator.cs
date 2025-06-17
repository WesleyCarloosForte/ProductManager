using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductValidator:AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductValidator()
        {
            RuleFor(x => x.name)
                .NotEmpty()
                .WithMessage("Product name is required!");
           
            RuleFor(x => x.price)
                .GreaterThan(0)
                .WithMessage("Price must be greater than zero.");


        }
    }
}
