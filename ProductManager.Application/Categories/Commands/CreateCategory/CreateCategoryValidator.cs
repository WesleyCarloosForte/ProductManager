using FluentValidation;
using ProductManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Application.Categories.Commands.CreateCategory
{
    public class CreateCategoryValidator:AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryValidator() 
        {
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

