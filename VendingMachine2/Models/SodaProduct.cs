using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine2.Models
{
    public class SodaProduct : Product, IProduct
    {
        const string product = "Soda";
        const decimal price = .95m;
        public override string ProductType { get { return product; } }

        public override decimal Price { get { return price; }  }
    }
}
