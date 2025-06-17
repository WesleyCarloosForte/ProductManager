using FluentValidation;
using ProductManager.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Application.Common.Exceptions
{
    public class DuplicateException :ValidationException, ICustomException
    {
  
        public DuplicateException(string message)
            : base(message)
        {
        }

        public DuplicateException(string entityName, string field, object value)
            : base($"Entity \"{entityName}\" already exists with {field}: \"{value}\".")
        {
        }
    }
}
