using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Application.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryValidator:AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryValidator() 
        {
            RuleFor(x => x.id)
                    .NotEmpty()
                .WithMessage("Category id is required!.");

            RuleFor(x => x.name)
              .NotEmpty()
              .WithMessage("Category name is required")
              .MinimumLength(4)
              .WithMessage("Category name must be at least 4 characters long.")
              .MaximumLength(100)
              .WithMessage("Category name must not exceed 100 characters.");

        }
    }
}
