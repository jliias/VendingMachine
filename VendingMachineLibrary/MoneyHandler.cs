using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineLibrary
{

    class MoneyHandler
    {
        public decimal moneyEntered;
        private Logger myLogger = new Logger("myLog.txt");

        public MoneyHandler()
        {
            this.moneyEntered = 0m;
        }

        public void FeedMoney(decimal amount)
        {
            moneyEntered += amount;
            myLogger.Log("Added " + amount + " EUR!");
        }

        public bool RemoveMoney(decimal amount)
        {
            if (this.moneyEntered > amount)
            {
                this.moneyEntered -= amount;
                myLogger.Log("Removed " + amount + " EUR!");
                myLogger.Log("You have " + moneyEntered + " EUR left.");
                return true;
            }
            else {
                return false;
            }
        }

    }
}
