// Author: Juha Liias 2021 
//  Use at your own risk!

namespace VendingMachineLibrary
{

    public class Food : Item
    {
        // Food class specific variable
        private float weight;

        public Food(string name, decimal price, int remaining, float weight) : base(name, price, remaining)
        {
            this.weight = weight;
        }
    }
}