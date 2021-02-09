using NUnit.Framework;
using VendingMachineLibrary;
using System.Collections.Generic;

namespace VendingMachineLibraryTests
{
    /* 
     Class implementing VendingMachineLibrary unit tests
     */


    [TestFixture]
    public class VendingMachineTests
    {
        private VendingMachine myMachine;
        private Food ryeBread;

        [SetUp]
        public void Setup()
        {
            // Create new vending machine
            myMachine = new VendingMachine();
            // Create Rye Bread and add it to vending machine
            ryeBread = new Food("Rye Bread", 5.2m, 10, 1.0f);

            // Place Rye Breads to vm slot A0
            myMachine.AddItem("A0", ryeBread);

            myMachine.moneyHandler.FeedMoney(100m);
        }

        [Test]
        public void CanAddItem()
        {
            // Create set of cabbages and add to vending machine
            Food cabbage = new Food("Cabbage", 1m, 5, 3.0f);
            myMachine.AddItem("B1", cabbage);

            // Get itemlist from machine
            Dictionary<string, Item> itemList = myMachine.GetItems();

            // Check that previously added key B1 exists
            Assert.That(itemList, Contains.Key("B1"));
            // Check that B1 contains Cabbage
            Assert.That("Cabbage", Is.EqualTo(itemList["B1"].name));
            // Also, check that there is no key B9 in itemlist (just for fun)
            Assert.AreNotEqual(itemList, Contains.Key("B9"));
        }

        [Test]
        public void CanBuyRyeBread()
        {
            // Check if you are able to get Rye Bread from A0 slot
            Assert.That("Rye Bread", Is.EqualTo(myMachine.BuyItem("A0")));

            // Check if you are able to get Rye Bread from B0 slot (expected result=false)
            Assert.AreNotEqual("Rye Bread", myMachine.BuyItem("B0"));
        }

        [Test]
        public void TryBuyTooExpensiveItem()
        {
            // Create AK47 item and add it to vending machine catalog
            Weapon AK47 = new Weapon("AK47", 1200m, 1, 10f);
            myMachine.AddItem("P6", AK47);

            Assert.That(null, Is.EqualTo(myMachine.BuyItem("P6")));
        }

        [Test]
        public void TryBuyAffordableItem()
        {
            // Create AK47 item and add it to vending machine catalog
            Weapon AK47 = new Weapon("AK47", 1200m, 1, 10f);
            myMachine.AddItem("P6", AK47);

            // Add some more money to vending machine
            myMachine.moneyHandler.FeedMoney(1200m);

            Assert.That("AK47", Is.EqualTo(myMachine.BuyItem("P6")));
        }

        [Test]
        public void AddMoneyToMachine()
        {
            decimal moneyBefore = myMachine.moneyHandler.moneyEntered;
            myMachine.moneyHandler.FeedMoney(100m);

            // Check that amount of money matches
            Assert.That(moneyBefore + 100m, Is.EqualTo(myMachine.moneyHandler.moneyEntered));
        }

        [Test]
        public void RemoveMoneyFromMachine()
        {
            decimal moneyBefore = myMachine.moneyHandler.moneyEntered;
            myMachine.moneyHandler.RemoveMoney(50m);

            Assert.That(moneyBefore - 50m, Is.EqualTo(myMachine.moneyHandler.moneyEntered));
        }


    }
}