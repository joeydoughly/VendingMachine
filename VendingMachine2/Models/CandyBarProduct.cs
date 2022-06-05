using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine2.Models
{
    public class CandyBarProduct : Product, IProduct
    {
        const string product = "Candy Bar";
        const decimal price = .60m;
        public override string ProductType { get { return product; } }

        public override decimal Price { get { return price; }  }
    }
}
