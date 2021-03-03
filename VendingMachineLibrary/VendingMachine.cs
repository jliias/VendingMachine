// Author: Juha Liias 2021 
//  Use at your own risk!

using System.Collections.Generic;

namespace VendingMachineLibrary
{
    public class VendingMachine
    {
        // list for items that are loaded to vending machine
        private Dictionary<string, Item> itemList = new Dictionary<string, Item>();
 
        public MoneyHandler moneyHandler { get; }

        // Logger instance, use output file "myLog.txt"
        private Logger myLogger = new Logger("myLog.txt");

        public VendingMachine()
        {
            this.myLogger.Log(2, "New vending machine created!");
            this.moneyHandler = new MoneyHandler();
        }

        // Method to add new items to machine
        //  key: item(s) position tag in vending machine user interface
        //  newItem: which item is placed to position defined by key 
        public void AddItem(string key, Item newItem)
        {
            // If key already exists, replace slot content with newItem
            if (itemList.ContainsKey(key))
            {
                this.myLogger.Log(3, "Replacing slot " + key + " content!");
                itemList[key] = newItem;
            }
            else
            {
                this.myLogger.Log(2, "Adding new item " + newItem.name + " to slot " + key);
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
                decimal price = itemList[key].price;

                if (this.moneyHandler.moneyEntered >= price)
                {
                    if (itemList[key].RemoveItem())
                    {
                        this.myLogger.Log(2, "---------------------------------------------");
                        this.myLogger.Log(2, "Buying Item: " + returnString);
                        this.moneyHandler.RemoveMoney(price);
                        this.myLogger.Log(2,"---------------------------------------------");
                        return returnString;
                    }
                    else
                    {
                        this.myLogger.Log(3, "Item " + key + " not found from catalog!");
                    }
                }
                else
                {
                    this.myLogger.Log(3, "You have not enough money for this item!");
                }
            }
            else
            {
                this.myLogger.Log(3, "Item not found from catalog!");
            }
            return null;
        }

        // Return list of all items in vending machine
        public Dictionary<string, Item> GetItems()
        {
            return itemList;
        }

    }
}
