using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class Candy : VendingItems
    {
        public Candy(string name, decimal cost) : base(name, cost)
        {
            
        }

        public override string Consume()
        {
            return "Munch Munch, Yum!";
        }
    }
}
