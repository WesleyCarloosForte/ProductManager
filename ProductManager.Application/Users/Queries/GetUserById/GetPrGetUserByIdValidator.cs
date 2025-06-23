using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Application.Users.Queries.GetUserById
{
    public class GetPrGetUserByIdValidator : AbstractValidator<GetUserByIdQuery>
    {
        public GetPrGetUserByIdValidator() 
        {
            RuleFor(x => x.id)
                    .NotEmpty()
                    .WithMessage("Invalid parameter Id");
        }

    }
}
