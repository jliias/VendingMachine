using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineLibrary
{
    public class Logger
    {
        public void LogEvent(string msg)
        {
            DateTime thisTime = DateTime.Now;
            string thisTimeString = thisTime.ToString("dd/MM/yyyy HH:mm:ss");

            string outLine = $"[{thisTimeString}] : {msg}";

            Console.WriteLine(outLine);
        }
    }

}

