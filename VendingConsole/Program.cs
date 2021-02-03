using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachineLibrary;

namespace VendingConsole
{
    class Program
    {
        enum ItemType { food, drink, weapon };

        static void Main(string[] args)
        {
            List<Item> testItems = new List<Item>();

            VendingMachine myMachine = new VendingMachine();

            Item bread = new Item("bread", 5, "food");

            myMachine.AddItem(bread);

            testItems = myMachine.ListItems();

            foreach (Item i in testItems) {
                Console.WriteLine(i.GetName() + " : " + i.GetPrice());
            }

        }
    }
}
