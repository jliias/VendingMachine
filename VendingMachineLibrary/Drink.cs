using System;

namespace VendingMachineLibrary
{
    public class Drink : Item
    {
        private float healAmount;

        public Drink(string name, decimal price, int remaining, float healAmount) : base(name, price, remaining)
        {
            this.healAmount = healAmount;
        }
    }
}