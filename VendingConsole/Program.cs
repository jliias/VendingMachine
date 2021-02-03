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

            Item bread = new Item("bread", 5, VendingMachineLibrary.ItemType.food);
            Item beer = new Item("beer", 10, VendingMachineLibrary.ItemType.drink);
            Item AK47 = new Item("AK-47", 1000, VendingMachineLibrary.ItemType.weapon);

            myMachine.AddItem(bread);
            myMachine.AddItem(beer);
            myMachine.AddItem(AK47);

            testItems = myMachine.ListItems();

            foreach (Item i in testItems) {
                Console.WriteLine(i.GetName() + " : " + i.GetPrice());
            }

        }
    }
}
