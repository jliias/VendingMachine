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
        //private List<Item> itemList;
        public Dictionary<string, Item> itemList = new Dictionary<string, Item>();

        private Logger myLogger = new Logger();

        public VendingMachine()
        {
            //this.itemList = new List<Item>();
        }

        // Method to add new items to machine
        public void AddItem(string key, Item newItem)
        { 
            itemList.Add(key, newItem);
        }

        // Method for getting list of items
        //public Dictionary<string, Item> ListItems()
        //{
        //    if (itemList.Count > 0)
        //    {
        //        return itemList;
        //    }

        //    return null;
        //}

        public void BuyItem(string key)
        {
            // Item can be bought if:
            // A) it exists in vending machine
            // B) There are >0 items left
            // C) User has enough money
            if (itemList.ContainsKey(key)
                && itemList[key].RemoveItem())
            {
                this.myLogger.LogEvent("Buying Item: " + itemList[key].name);
                Console.WriteLine("Item Bought!");
            }
            else {
                Console.WriteLine("No such item!");
            }
        }

        public void ShowItems()
        {
            Console.WriteLine($"{"Pos".PadRight(4)} {"Stock"} { "Product".PadRight(47) } { "Price".PadLeft(7)}");
            foreach (KeyValuePair<string, Item> kv in this.itemList)
            {
                if (kv.Value.remaining > 0)
                {
                    string itemNumber = kv.Key.PadRight(5);
                    string itemsRemaining = kv.Value.remaining.ToString().PadRight(5);
                    string productName = kv.Value.name.PadRight(40);
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
