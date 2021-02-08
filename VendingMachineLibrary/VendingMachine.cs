using System;
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
        private MoneyHandler moneyHandler;

        // Logger instance, use output file "myLog.txt"
        private Logger myLogger = new Logger("myLog.txt");

        public VendingMachine()
        {
            this.moneyHandler = new MoneyHandler();
            this.moneyHandler.FeedMoney(100m);
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
                decimal price = itemList[key].price;

                if (this.moneyHandler.moneyEntered >= price)
                {
                    if (itemList[key].RemoveItem())
                    {
                        this.myLogger.Log("Buying Item: " + returnString);
                        this.moneyHandler.RemoveMoney(price);
                        return returnString;
                    }
                    else
                    {
                        this.myLogger.Log("Item " + key + " not found from catalog!");
                    }
                }
                else
                {
                    this.myLogger.Log("You have not enough money for this item!");
                }
            }
            else
            {
                this.myLogger.Log("Item not found from catalog!");
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
