// Author: Juha Liias 2021 
//  Use at your own risk!

using System;
using System.IO;

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

        public void LogInformation(string msg)
        {
            // Build output string
            string outLine = $"INFO [{GetDateString()}] : {msg}";
            WriteToLogFile(outLine);
        }

        public void LogWarning(string msg)
        {
            // Build output string
            string outLine = $"WARNING [{GetDateString()}] : {msg}";
            WriteToLogFile(outLine);
        }

        public void LogError(string msg)
        {
            // Build output string
            string outLine = $"ERROR [{GetDateString()}] : {msg}";
            WriteToLogFile(outLine);
        }

        private string GetDateString()
        {
            // Timestamp for log
            DateTime timeNow = DateTime.Now;
            string timeNowString = timeNow.ToString("dd/MM/yyyy HH:mm:ss");
            return timeNowString;
        }

        private void WriteToLogFile(string outString)
        {
            // Write output string to the specified file
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(logFileName, true))
                {
                    streamWriter.WriteLine(outString);
                }
            }
            catch
            {
                Console.WriteLine("Logger: Error when writing to log file!");
            }
        }
    }

}

