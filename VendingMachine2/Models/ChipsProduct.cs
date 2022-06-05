using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine2.Models
{
    public class ChipsProduct : Product, IProduct
    {
        const string product = "Chips";
        const decimal price = .99m;
        public override string ProductType { get { return product; } }

        public override decimal Price { get { return price; } }

    }
}
