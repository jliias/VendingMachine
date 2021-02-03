using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineLibrary
{
    enum ItemType { food, drink, weapon };

    public class VendingMachine
    {
        // list for items that are loaded to vending machine
        private List<Item> itemList;

        public VendingMachine()
        {
            this.itemList = new List<Item>();
        }

        public void AddItem(Item newItem)
        {
            itemList.Add(newItem);
        }

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
        public string itemType;

        public Item(string name, int price, string itemType)
        {
            this.name = name;
            this.price = price;
            this.itemType = itemType;
        }

        public string GetName()
        {
            return this.name;
        }

        public int GetPrice()
        {
            return this.price;
        }
    }
}
