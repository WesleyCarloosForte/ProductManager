using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Application.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryValidator:AbstractValidator<DeleteCategoryCommand>
    {
        public DeleteCategoryValidator() 
        {
            RuleFor(x => x.id)
                .NotEmpty()
                .WithMessage("Category id is required!.");
        }
    }
}
