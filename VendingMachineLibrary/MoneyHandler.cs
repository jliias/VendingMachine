namespace VendingMachineLibrary
{

    public class MoneyHandler
    {
        private Logger myLogger = new Logger("myLog.txt");

        public MoneyHandler()
        {
            this.moneyEntered = 0m;
        }

        // Amount of money in vending machine
        public decimal moneyEntered { get; private set; }

        // Method for feeding more money to machine
        public void FeedMoney(decimal amount)
        {
            moneyEntered += amount;
            myLogger.Log("Added " + amount + " EUR!");
        }

        // Method for removing money
        public bool RemoveMoney(decimal amount)
        {
            if (this.moneyEntered > amount)
            {
                myLogger.Log("You have " + moneyEntered + " EUR before buying.");
                this.moneyEntered -= amount;
                myLogger.Log("Removed " + amount + " EUR!");
                myLogger.Log("You have " + moneyEntered + " EUR left after buying.");
                return true;
            }
            else {
                return false;
            }
        }

    }
}
