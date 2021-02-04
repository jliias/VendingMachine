using System;

namespace VendingMachineLibrary
{

    public class Food : Item
    {
        private float weight;

        public Food(string name, int price, int remaining, float weight) : base(name, price, remaining)
        {
            this.weight = weight;
        }
    }
}