using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Application.Users.Commands.DeleteUser
{
    public class DeleteUserValidator:AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserValidator()
        {
            RuleFor(x => x.id)
                .NotEmpty()
                .WithMessage("Invalid parameter Id");
        }
    }
}
