using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Application.Products.Commands.DeleteProduct
{
    public class DeleteProductValidator:AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductValidator()
        {
            RuleFor(x => x.id)
                .NotEmpty()
                .WithMessage("Invalid parameter Id");
        }
    }
}
