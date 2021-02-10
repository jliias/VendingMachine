// Author: Juha Liias 2021 
//  Use at your own risk!

using NUnit.Framework;
using VendingMachineLibrary;
using System.Collections.Generic;

// Class implementing VendingMachineLibrary unit tests

namespace VendingMachineLibraryTests
{
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
        public void CanAddFood()
        {
            // Create set of cabbages and add to vending machine
            Food cabbage = new Food("Cabbage", 1m, 5, 3.0f);
            myMachine.AddItem("F1", cabbage);

            // Get itemlist from machine
            Dictionary<string, Item> itemList = myMachine.GetItems();

            // Check that slot B1 contains Cabbage
            Assert.That("Cabbage", Is.EqualTo(itemList["F1"].name));
        }

        [Test]
        public void CanAddDrink()
        {
            // Create 6-pack of beer and add to vending machine
            Drink beer = new Drink("Beer", 3m, 6, 5.0f);
            myMachine.AddItem("B1", beer);

            // Get itemlist from machine
            Dictionary<string, Item> itemList = myMachine.GetItems();

            // Check that slot B1 contains Cabbage
            Assert.That("Beer", Is.EqualTo(itemList["B1"].name));
        }

        [Test]
        public void CanAddWeapon()
        {
            // Create AK-47 and add to vending machine
            Weapon AK47 = new Weapon("AK47", 1200m, 1, 20.0f);
            myMachine.AddItem("G1", AK47);

            // Get itemlist from machine
            Dictionary<string, Item> itemList = myMachine.GetItems();

            // Check that slot B1 contains Cabbage
            Assert.That("AK47", Is.EqualTo(itemList["G1"].name));
        }

        [Test]
        public void CanBuyRyeBreadFromA0()
        {
            // Check if you are able to get Rye Bread from A0 slot
            Assert.That("Rye Bread", Is.EqualTo(myMachine.BuyItem("A0")));
        }

        [Test]
        public void CannotBuyRyeBreadFromB0()
        {
            string item = "Rye Bread";
            // Check if you are able to get Rye Bread from B0 slot (expected result=false)
            Assert.That(item, Is.Not.EqualTo(myMachine.BuyItem("B0")));
        }


        [Test]
        public void CannotBuyTooExpensiveItem()
        {
            // Create AK47 item and add it to vending machine catalog
            Weapon AK47 = new Weapon("AK47", 1200m, 1, 10f);
            myMachine.AddItem("P6", AK47);

            Assert.That(null, Is.EqualTo(myMachine.BuyItem("P6")));
        }

        [Test]
        public void CanBuyAffordableItem()
        {
            // Create AK47 item and add it to vending machine catalog
            Weapon AK47 = new Weapon("AK47", 1200m, 1, 10f);
            myMachine.AddItem("P6", AK47);

            // Add some more money to vending machine
            myMachine.moneyHandler.FeedMoney(1200m);

            Assert.That("AK47", Is.EqualTo(myMachine.BuyItem("P6")));
        }

        [Test]
        public void CanAddMoneyToMachine()
        {
            // Check how much money is in machine in the beginning
            decimal moneyBefore = myMachine.moneyHandler.moneyEntered;

            // Feed 100 units of money
            myMachine.moneyHandler.FeedMoney(100m);

            // Check that amount of money matches with what is expected (100 units more than in beginning)
            Assert.That(moneyBefore + 100m, Is.EqualTo(myMachine.moneyHandler.moneyEntered));
        }

        [Test]
        public void CanRemoveMoneyFromMachine()
        {
            // Check how much money is in machine in the beginning
            decimal moneyBefore = myMachine.moneyHandler.moneyEntered;

            // Remove 50 units of money
            myMachine.moneyHandler.RemoveMoney(50m);

            // Check that amount of money matches with what is expected (50 units less than in beginning)
            Assert.That(moneyBefore - 50m, Is.EqualTo(myMachine.moneyHandler.moneyEntered));
        }
    }
}