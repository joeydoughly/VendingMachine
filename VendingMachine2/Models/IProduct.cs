using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine2.Models
{
    public interface IProduct
    {
        string ProductType { get; }

        decimal Price { get; }

        int InventoryInStock { get; set; }
    }
}
