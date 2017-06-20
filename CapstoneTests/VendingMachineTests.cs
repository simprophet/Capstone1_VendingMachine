using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace Capstone.Classes
{
    [TestClass]
    public class VendingMachineTests
    {
        [TestMethod]
        public void VendingMachine_FeedMoneyAndBalanceTests()
        {
            VendingMachine vm1 = new VendingMachine();
            VendingMachine vm2 = new VendingMachine();

            vm1.FeedMoney(10);
            vm1.FeedMoney(1);

            vm2.FeedMoney(5);
            vm2.FeedMoney(2);
            
            Assert.AreEqual(11, vm1.Balance);
            Assert.AreEqual(7, vm2.Balance);
        }

        [TestMethod]
        public void VendingMachine_PurchaseTests()
        {
            VendingMachine vm1 = new VendingMachine();
            VendingMachine vm2 = new VendingMachine();

            vm1.FeedMoney(1);
            vm2.FeedMoney(10);

            string item1 = "A1";
            string item2 = "D3";

            Assert.ReferenceEquals(item1, vm1.Purchase("A1"));
            Assert.ReferenceEquals(item2, vm1.Purchase("D3"));
        }

        [TestMethod]
        public void VendingMachine_CompleteTransactionAndChangeTests()
        {
            VendingMachine vm1 = new VendingMachine();
            VendingMachine vm2 = new VendingMachine();

            vm1.FeedMoney(10);
            vm2.FeedMoney(10);

            vm1.Purchase("A1");
            vm2.Purchase("D3");

            Assert.ReferenceEquals("Quarters: 27| Dimes : 2| Nickels : 0", vm1.CompleteTransaction().ToString());
            Assert.ReferenceEquals(9.25M, vm1.CompleteTransaction());
        }

        [TestMethod]
        public void VendingMachine_IsSoldOutTests()
        {
            VendingMachine vm1 = new VendingMachine();
            VendingMachine vm2 = new VendingMachine();

            vm1.FeedMoney(10);
            vm1.FeedMoney(10);

            Assert.ReferenceEquals(false, vm1.Purchase("A2"));
            vm1.Purchase("A2");
            Assert.ReferenceEquals(false, vm1.Purchase("A2"));
            vm1.Purchase("A2");
            Assert.ReferenceEquals(false, vm1.Purchase("A2"));
            vm1.Purchase("A2");
            Assert.ReferenceEquals(false, vm1.Purchase("A2"));
            vm1.Purchase("A2");
            Assert.ReferenceEquals(false, vm1.Purchase("A2"));
            vm1.Purchase("A2");
            Assert.ReferenceEquals(true, vm1.Purchase("A2"));

            vm2.FeedMoney(10);

            Assert.ReferenceEquals(false, vm1.Purchase("D3"));
            vm2.Purchase("D3");
            Assert.ReferenceEquals(false, vm1.Purchase("D3"));
        }
    }
}
