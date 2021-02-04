using System;

namespace VendingMachineLibrary
{
    public class Weapon : Item
    {
        private float damage;

        public Weapon(string name, int price, int remaining, float damage) : base(name, price, remaining)
        {
            this.damage = damage;
        }
    }
}