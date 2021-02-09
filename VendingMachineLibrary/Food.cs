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