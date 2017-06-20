using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class Change
    {
        private int numOfQuarters = 0;
        private int numOfDimes = 0;
        private int numOfNickels = 0;

        public Change(decimal dollarAmount)
        {
            const decimal Quarter = 0.25M;
            const decimal Dime = 0.10M;
            const decimal Nickel = 0.05M;

            decimal moneyBack = Math.Abs(dollarAmount);

            while (moneyBack >= Quarter)
            {
                moneyBack -= Quarter;
                numOfQuarters++;
            }

            while (moneyBack >= Dime)
            {
                moneyBack -= Dime;
                numOfDimes++;
            }

            while (moneyBack >= Nickel)
            {
                moneyBack -= Nickel;
                numOfNickels++;
            }
        }

        public override string ToString()
        {
            string totalChange = $"Quarters : {numOfQuarters}| Dimes : {numOfDimes}| Nickels : {numOfNickels}";
            return totalChange;
        }

    }
}
