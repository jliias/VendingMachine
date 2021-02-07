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

        public void Menu()
        {

            VendingMachine myMachine = new VendingMachine();

            Food ryeBread = new Food("Rye Bread", 5, 10, 1.0f);
            Food cabbage = new Food("Cabbage", 4, 5, 0.5f);
            Drink water = new Drink("Tap water", 3, 8, 12f);
            Drink soda = new Drink("Soda", 6, 5, 15f);
            Weapon ak47 = new Weapon("Ak-47", 1200, 1, 100f);

            myMachine.AddItem("A1", ryeBread);
            myMachine.AddItem("A2", cabbage);
            myMachine.AddItem("C3", water);
            myMachine.AddItem("C4", soda);
            myMachine.AddItem("D6", ak47);
            //myMachine.AddItem(AK47);

            ShowItems(myMachine);

            myMachine.BuyItem("D6");
            myMachine.BuyItem("D6");

            ShowItems(myMachine);

            //while (true)
            //{ 
                
            //}

        }

        public void ShowItems(VendingMachine vm)
        {
            Console.WriteLine($"{"Pos".PadRight(5)} {"Stock"} { "Product".PadRight(42) } { "Price".PadLeft(7)}");
            foreach (KeyValuePair<string, Item> kv in vm.GetItems())
            {
                if (kv.Value.remaining > 0)
                {
                    string itemNumber = kv.Key.PadRight(5);
                    string itemsRemaining = kv.Value.remaining.ToString().PadRight(4);
                    string productName = kv.Value.name.PadRight(42);
                    string price = kv.Value.price.ToString().PadLeft(7);
                    Console.WriteLine($" {itemNumber} {itemsRemaining} {productName} {price}");
                }
                else
                {
                    Console.WriteLine($" {kv}: {kv.Value.name} not found.");
                }
            }
        }

    }
}
