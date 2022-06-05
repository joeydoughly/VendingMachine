using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine2.Repository;

namespace VendingMachine2.Models
{
    public abstract class Product
    {
        public abstract string ProductType { get; }

        public abstract decimal Price { get; }

        public int InventoryInStock { get; set; }


    }
}
