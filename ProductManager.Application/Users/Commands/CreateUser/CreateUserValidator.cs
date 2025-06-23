using FluentValidation;
using ProductManager.Domain.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Application.Users.Commands.CreateUser
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.fullName)
              .NotNull().WithMessage("Name is required.")
              .WithMessage("Name cannot be empty.");

            RuleFor(x => x.login)
                .NotNull().WithMessage("Login is required.")
                .WithMessage("Login cannot be empty.");

            RuleFor(x => x.password)
                .NotNull().WithMessage("Password is required.")
                .WithMessage("Password hash cannot be empty.");

            RuleFor(x => x.Permission)
                .NotNull().WithMessage("Permissions list cannot be null.")
                .Must(p => p.Any()).WithMessage("At least one permission must be assigned.")
                .Must(AllPermissionsAreValid).WithMessage("One or more permissions are invalid.");
        }

        private bool AllPermissionsAreValid(List<Permission> permissions)
        {
            var all = Enum.GetValues<Permission>();
            return permissions.All(p => all.Contains(p));
        }
    }
}
