using ProductManager.Domain.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Application.DTO
{
    public class BaseDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public EntityStatus Status { get; set; }
    }
}
