// Author: Juha Liias 2021 
// Use at your own risk!
// This application is just for testing VendingMachine class library.

using System;
using System.Collections.Generic;
using VendingMachineLibrary;

namespace VendingConsole
{
    /* 
    This will demonstrate the usage of VendingMachineLibrary
    with simple user interface. 
     */
    class VendingDemo
    {
        VendingMachine myMachine;

        public void Menu()
        {
            // Let's create an example vending machine
            myMachine = new VendingMachine();

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

            // Get some money to machine
            decimal amount = ReadDecimal("How much money you want to put to vending machine?");
            myMachine.moneyHandler.FeedMoney(amount);

            Console.Clear();

            // Main loop, "Q" to exit
            while (true)
            {
                // Show available items in machine
                ShowItems(myMachine);

                // Instructions for user
                Console.WriteLine("Money in Vending Machine: " + myMachine.moneyHandler.moneyEntered);
                Console.WriteLine("\nEnter item position or:\n" +
                    "  \"F\" to add food\n" +
                    "  \"D\" to add drink\n" +
                    "  \"W\" to add weapon\n" +
                    "  \"M\" to add money\n" +
                    "  \"Q\" to quit.");
                string input = Console.ReadLine().ToUpper();

                // Check user input:
                //   Q: Quit
                //   F: Create food item
                //   D: Create drink item
                //   W: Create weapon item
                //   other inputs are intepreted as slot selection
                if (input == "Q")
                {
                    Console.WriteLine("Exiting...Bye!");
                    break;
                }
                else if (input == "M")
                {
                    Console.Clear();
                    decimal newMoney = ReadDecimal("How much you want to add money?");
                    myMachine.moneyHandler.FeedMoney(newMoney);
                }
                else if ((input == "F") || (input == "D") || (input == "W"))
                {
                    Console.Clear();
                    Console.WriteLine("Creating new item type " +
                        (input == "F" ? "Food" : input == "D" ? "Drink" : "Weapon"));
                    AddNewItem(input);
                }
                else
                {
                    // Try to buy item from slot given by user.
                    string itemBought = myMachine.BuyItem(input);
                    if (itemBought != null)
                    {
                        Console.WriteLine("You bought " + itemBought + "!\nPress any key to continue.");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Something went wrong! Check machine balance or item availability!\nPress any key to continue.");
                        Console.ReadLine();
                    }
                }

                //Console.ReadLine();
                Console.Clear();
            }
        }

        // Show contents of vending machine
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

        // Method for adding new item
        public void AddNewItem(string itemType)
        {
            // Get info on new item: position, name, price
            Console.WriteLine("Enter item position:");
            string thisPos = Console.ReadLine();
            Console.WriteLine("Enter item name:");
            string thisName = Console.ReadLine();
            decimal thisPrice = ReadDecimal("Enter item price:");
            int thisCount = ReadInt("Enter number of items:");

            // Get input for additional properties values
            // Food: weight
            // Drink: healing
            // Weapon: damage
            switch (itemType)
            {
                case "F":
                    float thisWeight = ReadFloat("Enter food weight:");
                    Food newFood = new Food(thisName, thisPrice, thisCount, thisWeight);
                    myMachine.AddItem(thisPos, newFood);
                    break;
                case "D":
                    float thisHealing = ReadFloat("Enter amount of healing:");
                    Drink newDrink = new Drink(thisName, thisPrice, thisCount, thisHealing);
                    myMachine.AddItem(thisPos, newDrink);
                    break;
                case "W":
                    //Console.WriteLine("Adding Weapon");
                    float thisDamage = ReadFloat("Enter amount of damage:");
                    Weapon newWeapon = new Weapon(thisName, thisPrice, thisCount, thisDamage);
                    myMachine.AddItem(thisPos, newWeapon);
                    break;
                default:
                    Console.WriteLine("Illegal item type!");
                    break;
            }
        }

        #region Input validators
        // Temporary solution: planning to combine separate decimal, 
        // int and float methods with single generic method. Need to 
        // study how to make <T>.TryParse() working...

        // Method for getting valid input for decimal
        public decimal ReadDecimal(string myString)
        {
            while (true)
            {
                Console.WriteLine(myString);
                string number = Console.ReadLine();
                if (decimal.TryParse(number, out decimal validNumber))
                {
                    return validNumber;
                }
                Console.Clear();
                Console.WriteLine("Please give a number!");
            }
        }

        // Method for getting valid input for integer
        // Temporary solution: planning to combine all 3 Read* methods
        public int ReadInt(string myString)
        {
            while (true)
            {
                Console.WriteLine(myString);
                string number = Console.ReadLine();
                if (int.TryParse(number, out int validNumber))
                {
                    return validNumber;
                }
                Console.Clear();
                Console.WriteLine("Please give a number!");
            }
        }

        // Method for getting valid input for float
        // Temporary solution: planning to combine all 3 Read* methods
        public float ReadFloat(string myString)
        {
            while (true)
            {
                Console.WriteLine(myString);
                string number = Console.ReadLine();
                if (float.TryParse(number, out float validNumber))
                {
                    return validNumber;
                }
                Console.Clear();
                Console.WriteLine("Please give a number!");
            }
        }


        /* 
         Need to figure out how to combine three methods above to single method. 
         Something like this:
         */
        //public T ParseInput<T>(string myString)
        //{
        //    while (true)
        //    {
        //        Console.WriteLine(myString);
        //        string number = Console.ReadLine();
        //        if (T.TryParse(number, out T validNumber))
        //        {
        //            return validNumber;
        //        }
        //        Console.Clear();
        //        Console.WriteLine("Please give a number!");
        //    }
        //}
        #endregion
    }
}
