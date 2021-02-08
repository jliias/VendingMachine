using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachineLibrary;

namespace VendingConsole
{
    class VendingDemo
    {
        //enum ItemType { food, drink, weapon };

        private decimal playerMoney = 1250m;

        public void Menu()
        {
            // Let's create an example vending machine
            VendingMachine myMachine = new VendingMachine();

            // Create some goods to add
            Food ryeBread = new Food("Rye Bread", 5.2m, 10, 1.0f);
            Food cabbage = new Food("Cabbage", 4m, 5, 0.5f);
            Drink water = new Drink("Tap water", 3m, 8, 12f);
            Drink soda = new Drink("Soda", 6m, 5, 15f);
            Food orange = new Food("Orange", 2.2m, 8, 0.6f);
            Weapon ak47 = new Weapon("Ak-47", 1200m, 1, 100f);

            // ...and add goods to vending machine slots
            myMachine.AddItem("A1", ryeBread);
            myMachine.AddItem("A2", cabbage);
            myMachine.AddItem("C3", water);
            myMachine.AddItem("C4", soda);
            myMachine.AddItem("C3", orange);
            myMachine.AddItem("D6", ak47);

            while (true)
            {
                ShowItems(myMachine);
                Console.WriteLine("Enter slot name or Q to quit:");
                string input = Console.ReadLine();

                if (input.ToUpper() == "Q")
                {
                    Console.WriteLine("Exit");
                    break;
                }
                else
                {
                    myMachine.BuyItem(input);
                }

                //Console.ReadLine();
                Console.Clear();
            }
        }

        public void ShowItems(VendingMachine vm)
        {
            // Header for content list
            Console.WriteLine($"{"Pos".PadRight(5)} {"Stock"} { "Product".PadRight(42) } { "Price".PadLeft(7)}");

            // Write out vending machine content
            foreach (KeyValuePair<string, Item> kv in vm.GetItems())
            {
                string itemNumber = kv.Key.PadRight(5);
                string itemsRemaining = kv.Value.remaining.ToString().PadRight(4);
                string productName;
                if (kv.Value.remaining > 0)
                    productName = kv.Value.name.PadRight(42);
                else
                    productName = (kv.Value.name + " *** OUT OF STOCK! *** ").PadRight(42);
                string price = (kv.Value.price.ToString() + " EUR").PadLeft(10);

                Console.WriteLine($" {itemNumber} {itemsRemaining} {productName} {price}");
            }
        }

    }
}
