using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Domain.Common.Enums
{
    public enum Permission
    {
        Product_Read,
        Product_Write,
        Product_Delete,
        Category_Read,
        Category_Write,
        Category_Delete,
        User_Read,
        User_Write,
        User_Delete,
    }
}
