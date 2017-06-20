using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class Change_Tests
    {
        [TestMethod]
        public void Change_ConstructorTest()
        {
            Change c1 = new Change(0);
            Assert.AreEqual(new Change(0.0M).ToString(), c1.ToString());

            Change c2 = new Change(0.95M);
            Assert.AreEqual(new Change(0.95M).ToString(), c2.ToString());

            Change c3 = new Change(6);
            Assert.AreEqual(new Change(6).ToString(), c3.ToString());

            Change c4 = new Change(12.05M);
            Assert.AreEqual(new Change(12.05M).ToString(), c4.ToString());
        }

        [TestMethod]
        public void Change_ToStringTest()
        {
            // Test: Quarters & Dimes
            Change c0 = new Change(0.95M);
            Assert.AreEqual("Quarters : 3| Dimes : 2| Nickels : 0", c0.ToString());

            // Test: Quarters & Nickel
            Change c1 = new Change(0.55M);
            Assert.AreEqual("Quarters : 2| Dimes : 0| Nickels : 1", c1.ToString());

            // Test: Quarters Only
            Change c2 = new Change(2);
            Assert.AreEqual("Quarters : 8| Dimes : 0| Nickels : 0", c2.ToString());

            // Test: Dime & Nickel
            Change c3 = new Change(0.15M);
            Assert.AreEqual("Quarters : 0| Dimes : 1| Nickels : 1", c3.ToString());

            // Test: Dimes Only
            Change c4 = new Change(0.20M);
            Assert.AreEqual("Quarters : 0| Dimes : 2| Nickels : 0", c4.ToString());

            // Test: Nickel Only
            Change c5 = new Change(0.05M);
            Assert.AreEqual("Quarters : 0| Dimes : 0| Nickels : 1", c5.ToString());

            // Test: Quarters, Dimes, & Nickels
            Change c6 = new Change(2.9M);
            Assert.AreEqual("Quarters : 11| Dimes : 1| Nickels : 1", c6.ToString());

            // Test: No Money
            Change c7 = new Change(0);
            Assert.AreEqual("Quarters : 0| Dimes : 0| Nickels : 0", c7.ToString());
        }
    }
}
