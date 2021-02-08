using NUnit.Framework;
using VendingMachineLibrary;
using System.Collections.Generic;
using System.Linq;

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
            myMachine = new VendingMachine();
            ryeBread = new Food("Rye Bread", 5.2m, 10, 1.0f);

            // Place Rye Breads to vm slot A0
            myMachine.AddItem("A0", ryeBread);
        }

        [Test, Order(1)]
        public void CanAddItem()
        {
            Food cabbage = new Food("Cabbage", 1m, 5, 3.0f);
            myMachine.AddItem("B1", cabbage);

            Dictionary<string, Item> itemList = myMachine.GetItems();

            Assert.That(itemList, Contains.Key("B1"));
            Assert.AreNotEqual(itemList, Contains.Key("B9"));
        }

        [Test, Order(2)]
        public void CanBuyRyeBread()
        {
            // Check if you are able to get Rye Bread from A0 slot
            Assert.That("Rye Bread", Is.EqualTo(myMachine.BuyItem("A0")));

            // Check if you are able to get Rye Bread from B0 slot (expected result=false)
            Assert.AreNotEqual("Rye Bread", myMachine.BuyItem("B0"));
        }


    }
}