using ProductManager.Domain.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Application.Services
{
    public interface ITokenService
    {
        string GenerateToken(Guid userId, string login, List<Permission> permissions);
    }
}
