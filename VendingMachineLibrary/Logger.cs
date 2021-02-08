using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineLibrary
{
    public class Logger : ILogger
    {

        private string logFileName;

        public Logger()
        {
            this.logFileName = "log.txt";
        }

        public Logger(string logFileName)
        {
            this.logFileName = logFileName;
        }

        public void Log(string msg)
        {
            // Timestamp for log
            DateTime thisTime = DateTime.Now;
            string thisTimeString = thisTime.ToString("dd/MM/yyyy HH:mm:ss");

            // Build output string
            string outLine = $"[{thisTimeString}] : {msg}";

            //Console.WriteLine(outLine);

            try
            {
                using (StreamWriter streamWriter = new StreamWriter(logFileName, true))
                {
                    streamWriter.WriteLine(outLine);
                }
            }
            catch
            {
                Console.WriteLine("Logger: Error when writing to log file!");
                return;
            }
        }


    }

}

