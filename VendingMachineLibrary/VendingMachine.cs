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

        // Method to add new items to machine
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

        public void BuyItem()
        {

        }

        public void DisplayAllItems()
        {
            Console.WriteLine($"\n\n{"#".PadRight(5)} {"Stock"} { "Product".PadRight(47) } { "Price".PadLeft(7)}");
            foreach (Item kvp in this.itemList)
            {
                if (kvp.remaining > 0)
                {
                    //string itemNumber = kvp;
                    string itemsRemaining = kvp.remaining.ToString().PadRight(5);
                    string productName = kvp.name.PadRight(40);
                    string price = kvp.price.ToString("C").PadLeft(7);
                    Console.WriteLine($" {itemsRemaining} {productName} Costs: {price} each");
                }
                else
                {
                    Console.WriteLine($"{kvp}: {kvp.name} IS SOLD OUT.");
                }
            }
        }

    }

    public abstract class Item
    {
        public string name;
        public int price;
        public int remaining;

        public Item(string name, int price, int remaining)
        {
            this.name = name;
            this.price = price;
            this.remaining = remaining;
        }

        public string GetName()
        {
            return this.name.ToString();
        }

        public int GetPrice()
        {
            return this.price;
        }

        public bool remoteItem()
        {
            if (this.remaining > 0)
            {
                this.remaining--;
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class Food : Item
    {
        private float weight;

        public Food(string name, int price, int remaining, float weight) : base(name, price, remaining)
        {
            this.weight = weight;
        }
    }

    public class Drink : Item
    {
        private float healAmount;

        public Drink(string name, int price, int remaining, float healAmount) : base(name, price, remaining)
        {
            this.healAmount = healAmount;
        }
    }

    public class Weapon : Item
    {
        private float damage;

        public Weapon(string name, int price, int remaining, float damage) : base(name, price, remaining)
        {
            this.damage = damage;
        }
    }
}
