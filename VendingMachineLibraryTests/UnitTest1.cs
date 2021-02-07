using NUnit.Framework;
using VendingMachineLibrary;

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
        }

        [Test]
        public void CanBuyRyeBread()
        {
            // Place Rye Breads to vm slot A0
            myMachine.AddItem("A0", ryeBread);

            // Check if you are able to get Rye Bread from A0 slot
            Assert.That("Rye Bread", Is.EqualTo(myMachine.BuyItem("A0")));

            // Check if you are able to get Rye Bread from B0 slot (expected result=false)
            Assert.AreNotEqual("Rye Bread", myMachine.BuyItem("B0"));
        }
    }
}