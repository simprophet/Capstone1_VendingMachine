using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public abstract class VendingItems
    {
        private string nameOfItem;
        private decimal costOfItem;

        public abstract string Consume();

        public decimal CostOfItem
        {
            get { return this.costOfItem; }
        }

        public string NameOfItem
        {
            get { return this.nameOfItem; }
        }

        public VendingItems(string name, decimal cost)
        {
            this.nameOfItem = name;
            this.costOfItem = cost;
        }
    }
}
