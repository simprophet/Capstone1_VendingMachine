using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class VendingMachineCLI
    {
        private VendingMachine vendOMatic500;
        private List<VendingItems> purchasedItems = new List<VendingItems>();

        public List<VendingItems> PurchasedItems
        {
            get { return this.purchasedItems; }
        }

        public VendingMachineCLI()
        {
            vendOMatic500 = new VendingMachine();
        }

        private void DisplayHeader()
        {
            Console.WriteLine("Welcome to the Vend-O-Matic 500!!!".PadLeft(60));
            Console.WriteLine("".PadLeft(90, '-'));
        }

        private void DisplayItems()
        {
            Console.WriteLine("Slot:\t" + "Item:".PadRight(30) + "Cost:".PadRight(15) + "Quantity:");
            Console.WriteLine("".PadRight(62, '-'));
            foreach (KeyValuePair<string, List<VendingItems>> kvp in vendOMatic500.Items)
            {
                if (kvp.Value.Count > 0)
                {
                    string name = kvp.Value[0].NameOfItem;
                    string cost = kvp.Value[0].CostOfItem.ToString();
                    Console.WriteLine(kvp.Key + "\t" + name.PadRight(30) + cost.PadRight(15) + (kvp.Value.Count.ToString()));
                }
                else
                {
                    Console.WriteLine("Sold out!");
                }
            }
        }

        public void MainMenu()
        {
            DisplayHeader();

            Console.WriteLine("MAIN MENU".PadLeft(45));

            Console.WriteLine();
            while (true)
            {
                Console.WriteLine("(1) Display Vending Machine Items \n(2) Purchase \n(3) EXIT");
                string mainMenuInput = Console.ReadLine();

                Console.WriteLine();

                if (mainMenuInput == "1")
                {
                    Console.Clear();

                    DisplayHeader();
                    DisplayItems();

                    Console.WriteLine();
                    Console.WriteLine("Enter 0 to return to the Main Menu.");
                    string backToMenuInput = Console.ReadLine();
                    
                    if (backToMenuInput == "0")
                    {
                        Console.Clear();
                        MainMenu();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Please input a valid number");

                        DisplayHeader();
                        DisplayItems();

                        Console.WriteLine();
                        Console.WriteLine("Enter 0 to return to the Main Menu");
                        string backToMenuInput2 = Console.ReadLine();
                    }
                    Console.Clear();
                    MainMenu();
                }

                else if (mainMenuInput == "2")
                {
                    Console.Clear();
                    PurchaseMenu();
                }

                else if (mainMenuInput == "3")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Please input a valid number.");
                    MainMenu();
                }
            }
        }

        public void PurchaseMenu()
        {
            DisplayHeader();
            Console.WriteLine("PURCHASE MENU".PadLeft(45));
            Console.WriteLine();
            Console.WriteLine("(1) Feed Money \n(2) Select Product \n(3) Finish Transaction \n(4) Return to Main Menu");
            string purchaseMenuInput = Console.ReadLine();

            while (true)
            {
                if (purchaseMenuInput == "1")
                {
                    Console.WriteLine("Please insert money (we accept $1s, $2s, $5s, $10s): \n\n(OR enter 0 to return to purchase menu)");
                    Console.WriteLine("".PadRight(52, '-'));
                    Console.WriteLine();

                    string moneyInput = Console.ReadLine();

                    if ((moneyInput == "1") || (moneyInput == "2") || (moneyInput == "5") || (moneyInput == "10"))
                    {

                        vendOMatic500.FeedMoney(decimal.Parse(moneyInput));

                    }
                    else if(moneyInput == "0")
                    {
                        Console.Clear();
                        PurchaseMenu();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("We do not accept that currency!");
                    }
                    Console.WriteLine($"Current Balance: {vendOMatic500.Balance.ToString("C")}");
                }
                else if (purchaseMenuInput == "2")
                {
                    Console.Clear();
                    DisplayHeader();
                    Console.WriteLine();
                    Console.WriteLine($"Your current balance is: {vendOMatic500.Balance.ToString("C")}");
                    Console.WriteLine();
                    Console.WriteLine("".PadLeft(62, '-'));

                    DisplayItems();

                    Console.WriteLine();
                    Console.WriteLine("Please input a slot number:");
                    string slotNumber = Console.ReadLine().ToUpper();
                    Console.WriteLine();

                    if (vendOMatic500.Items.ContainsKey(slotNumber))
                    {
                        purchasedItems.Add(vendOMatic500.Purchase(slotNumber));

                        Thread.Sleep(2000);

                        Console.Clear();
                        PurchaseMenu();
                    }
                    else if(vendOMatic500.IsSoldOut(slotNumber))
                    {
                        Console.WriteLine("Sorry, that product is sold out!");

                        Thread.Sleep(5000);

                        Console.Clear();
                        PurchaseMenu();
                    }
                }
                else if (purchaseMenuInput == "3")
                {
                    Console.WriteLine("".PadRight(90, '-'));
                    Console.WriteLine();
                    Console.WriteLine("Please take your change: ");
                    Console.WriteLine();

                    Console.WriteLine(vendOMatic500.CompleteTransaction().ToString());
                    
                    foreach(VendingItems item in purchasedItems)
                    {
                        if (item != null)
                        {
                            Console.WriteLine(item.Consume());
                        }
                    }

                    Thread.Sleep(4000);
                    Console.Clear();
                    PurchaseMenu();
                }
                else if(purchaseMenuInput == "4")
                {
                    Console.Clear();
                    MainMenu(); 
                }
                else 
                {
                    Console.Clear();
                    Console.WriteLine("Please input a valid number.");
                    PurchaseMenu();
                }
            }
        }

        public void Display()
        {
            MainMenu();
        }
    }
}
