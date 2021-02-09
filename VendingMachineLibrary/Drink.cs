// Author: Juha Liias 2021 
//  Use at your own risk!

namespace VendingMachineLibrary
{
    public class Drink : Item
    {
        // Drink class specific variable
        private float healAmount;

        public Drink(string name, decimal price, int remaining, float healAmount) : base(name, price, remaining)
        {
            this.healAmount = healAmount;
        }
    }
}