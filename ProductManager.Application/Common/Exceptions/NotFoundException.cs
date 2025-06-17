using FluentValidation;
using ProductManager.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Application.Common.Exceptions
{
    public  class NotFoundException : ValidationException, ICustomException
    {
        public NotFoundException(string message) : base(message) 
        {
        
        }

        public NotFoundException(string name,object key): base($"Entity \"{name}\" with key ({key}) was not found.")
        {

        }
    }
}
