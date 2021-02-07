using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineLibrary
{
    public class Logger : ILogger
    {
        public void Log(string msg)
        {
            // Timestamp for log
            DateTime thisTime = DateTime.Now;
            string thisTimeString = thisTime.ToString("dd/MM/yyyy HH:mm:ss");

            // Build output string
            string outLine = $"[{thisTimeString}] : {msg}";

            Console.WriteLine(outLine);
        }
    }

}

