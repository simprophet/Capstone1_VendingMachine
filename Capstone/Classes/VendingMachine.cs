using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace Capstone.Classes
{
    public class VendingMachine
    { 
        private decimal balance;
        private Dictionary<string, List<VendingItems>> items;
     
        public Dictionary<string, List<VendingItems>> Items
        {
            get { return this.items; }
        }

        public decimal Balance
        {
            get { return this.balance; }
        }

        public VendingMachine()
        {
            string curDirectory = Directory.GetCurrentDirectory();
            string fileName = "vendingmachine.csv";
            string fullPath = Path.Combine(curDirectory, fileName);

            VendingMachFileReader fr = new VendingMachFileReader();
            this.items = fr.ReadInventory(fullPath);
        }

        public VendingMachine(Dictionary<string, List<VendingItems>> i)
        {
            this.items = i;
        }

        public void FeedMoney(decimal dollars)
        {
            const decimal oneDollar = 1;
            const decimal twoDollars = 2;
            const decimal fiveDollars = 5;
            const decimal tenDollars = 10;

            if (dollars == oneDollar)
            {
                balance += dollars;
            }
            else if (dollars == twoDollars)
            {
                balance += dollars;
            }
            else if (dollars == fiveDollars)
            {
                balance += dollars;
            }
            else if (dollars == tenDollars)
            {
                balance += dollars;
            }

            VendingMachFileWriter feedMoneyLog = new VendingMachFileWriter("");
            string currentDateAndTime = DateTime.Now.ToString("MM-dd-yyyy") + "|" + DateTime.Now.ToString("hh:mm:ss");
            string feedMoney = ("| FEED MONEY:  |".PadRight(27) + dollars.ToString("C").PadRight(7) + "|" + balance.ToString("C").PadLeft(7));
            feedMoneyLog.LogMessage(currentDateAndTime + feedMoney);
        }

        public VendingItems Purchase(string slot)
        {
            List<VendingItems> slotItems = new List<VendingItems>(this.items[slot]);

            VendingItems itemToBuy = null;

            if (!IsSoldOut(slot))
            {
                itemToBuy = slotItems[0];

                if (balance >= itemToBuy.CostOfItem)
                {
                    VendingMachFileWriter purchaseLog = new VendingMachFileWriter("");
                    string currentDateAndTime = DateTime.Now.ToString("MM-dd-yyyy") + "|" + DateTime.Now.ToString("hh:mm:ss");
                    string purchaseString = ("| " + $"{itemToBuy.NameOfItem}  {slot} :".PadRight(24) + "|" + balance.ToString("C").PadRight(7)
                                              + "|" + (balance - itemToBuy.CostOfItem).ToString("C").PadLeft(6));
                    purchaseLog.LogMessage(currentDateAndTime + purchaseString);

                    balance -= itemToBuy.CostOfItem;
                    items[slot].Remove(itemToBuy);

                    Console.WriteLine($"Your new balance is: {balance}");
                    Console.WriteLine();
                    Console.WriteLine("Dispensing...");
                    Thread.Sleep(2000);
                    Console.WriteLine("Please grab item.");
                }
                else
                {
                    Console.WriteLine("You don't have enough money for that!");
                    return null;
                }
                return itemToBuy;
            }
            else
            {
                Console.WriteLine("Sorry, we're sold out. Please choose different item");
            }
            return itemToBuy;
        }


        public Change CompleteTransaction()
        {
            Change moneyBack = new Change(balance);

            VendingMachFileWriter changeLog = new VendingMachFileWriter("");
            string currentDateAndTime = DateTime.Now.ToString("MM-dd-yyyy") + "|" + DateTime.Now.ToString("hh:mm:ss");
            string giveChangeString = ("| GIVE CHANGE:  |".PadRight(27) + balance.ToString("C").PadRight(7) + "|" + "$0.00".PadLeft(7));
            changeLog.LogMessage(currentDateAndTime + giveChangeString);

            balance = 0;

            return moneyBack;
        }

        public bool IsSoldOut(string slot)
        {
            try
            {
                return items[slot].Count == 0;
            }
            catch(KeyNotFoundException knf)
            {
                return true;
            }
        }
    }
}
