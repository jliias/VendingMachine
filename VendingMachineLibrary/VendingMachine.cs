﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineLibrary
{
    public enum ItemType { food, drink, weapon };

    public class VendingMachine
    {
        // list for items that are loaded to vending machine
        public Dictionary<string, Item> itemList = new Dictionary<string, Item>();

        // Logger instance
        private Logger myLogger = new Logger();

        public VendingMachine()
        {

        }

        // Method to add new items to machine
        //  key: item(s) position tag in vending machine user interface
        //  newItem: which item is placed to position defined by key 
        public void AddItem(string key, Item newItem)
        {
            // If key already exists, replace slot content with newItem
            if (itemList.ContainsKey(key))
            {
                this.myLogger.Log("Replacing slot " + key + " content!");
                itemList[key] = newItem;
            }
            else
            {
                itemList.Add(key, newItem);
            }
        }

        public string BuyItem(string key)
        {
            // Item can be bought if these are true:
            // A) it exists in vending machine (contains key)
            // B) There are >0 items left
            // C) User has entered enough money to vm
            if (itemList.ContainsKey(key))
            {
                string returnString = itemList[key].name;

                if (itemList[key].RemoveItem())
                {
                    this.myLogger.Log("Buying Item: " + itemList[key].name);
                    Console.WriteLine("Item Bought!");
                    return returnString;
                }
                else
                {
                    Console.WriteLine("No such item!");
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        // Return list of all items in vending machine
        public Dictionary<string, Item> GetItems()
        {
            return itemList;
        }

    }
}
