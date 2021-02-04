﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachineLibrary;

namespace VendingConsole
{
    class Program
    {
        //enum ItemType { food, drink, weapon };

        static void Main(string[] args)
        {

            VendingMachine myMachine = new VendingMachine();

            Food ryeBread = new Food("Rye Bread", 5, 10, 1.0f);
            Food cabbage = new Food("Cabbage", 4, 5, 0.5f);
            Drink water = new Drink("Tap water", 3, 8, 12f);
            Drink soda = new Drink("Soda", 6, 5, 15f);
            Weapon ak47 = new Weapon("Ak-47", 1200, 1, 100f);
            //Item bread = new Item("bread", 5, VendingMachineLibrary.ItemType.food);
            //Item beer = new Item("beer", 10, VendingMachineLibrary.ItemType.drink);
            //Item AK47 = new Item("AK-47", 1000, VendingMachineLibrary.ItemType.weapon);

            myMachine.AddItem(ryeBread);
            myMachine.AddItem(cabbage);
            myMachine.AddItem(water);
            myMachine.AddItem(soda);
            myMachine.AddItem(ak47);
            //myMachine.AddItem(AK47);

            myMachine.DisplayAllItems();

        }

        public void GetItems(VendingMachine machine)
        {

            List<Item> testItems = new List<Item>();

            testItems = machine.ListItems();

            foreach (Item i in testItems)
            {
                Console.WriteLine(i.GetName() + " : " + i.GetPrice());
            }
        }
    }
}
