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
        private List<Item> itemList;

        public VendingMachine()
        {
            this.itemList = new List<Item>();
        }

        // Method to add new item to machine
        public void AddItem(Item newItem)
        {
            itemList.Add(newItem);
        }

        // Method for getting list of items
        public List<Item> ListItems()
        {
            if (itemList.Count > 0)
            {
                return itemList;
            }

            return null;
        }
    }

    public class Item
    {
        private string name;
        private int price;
        private ItemType ItemType;

        public Item(string name, int price, ItemType itemType)
        {
            this.name = name;
            this.price = price;
            this.ItemType = itemType;
        }

        public string GetName()
        {
            return this.name.ToString();
        }

        public int GetPrice()
        {
            return this.price;
        }
    }
}
