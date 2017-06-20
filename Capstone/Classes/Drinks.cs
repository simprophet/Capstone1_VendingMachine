using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class Drinks : VendingItems
    {
        public Drinks(string name, decimal cost) : base(name, cost)
        {

        }

        public override string Consume()
        {
            return "Glug Glug, Yum!";
        }
    }
}
