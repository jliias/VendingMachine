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

        // Returns item name
        public string GetName()
        {
            return this.name.ToString();
        }

        // Returns item price
        public decimal GetPrice()
        {
            return this.price;
        }

        // Subtracts the number of items by 1 (if remaining > 0)
        // Returns true if successfull
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