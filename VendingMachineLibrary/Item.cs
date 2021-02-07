using System;

namespace VendingMachineLibrary
{
    public abstract class Item
    {
        public string name;
        public decimal price;
        public int remaining;

        public Item(string name, decimal price, int remaining)
        {
            this.name = name;
            this.price = price;
            this.remaining = remaining;
        }

        public string GetName()
        {
            return this.name.ToString();
        }

        public decimal GetPrice()
        {
            return this.price;
        }

        public bool RemoveItem()
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
}