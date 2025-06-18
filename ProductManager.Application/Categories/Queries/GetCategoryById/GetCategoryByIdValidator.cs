using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Application.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdValidator:AbstractValidator<GetCategoryByIdCommand>
    {
        public GetCategoryByIdValidator() 
        {
            RuleFor(x => x.id)
                .NotEmpty()
                .WithMessage("Category id is required!");
        }
    }
}
