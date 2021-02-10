// Author: Juha Liias 2021 
//  Use at your own risk!

using System;
using System.IO;

namespace VendingMachineLibrary
{
    // Logger class implementation
    public class Logger : ILogger
    {
        private string logFileName;

        // Constructor with no parameters:
        // Set output file name as default (log.txt)
        public Logger()
        {
            this.logFileName = "log.txt";
        }

        // Constructor withn logFile Name
        public Logger(string logFileName)
        {
            this.logFileName = logFileName;
        }

        // Log without severity level information
        public void Log(string msg)
        {
            // Build output string
            string outLine = $"MSG [{GetDateString()}] : {msg}";
            WriteToLogFile(outLine);
        }

        // Log with severity information
        public void Log(int level, string msg)
        {
            // Select identifier based on severity
            string logLevelString = "";
            switch (level)
            {
                case 0:
                    logLevelString = "TRACE";
                    break;
                case 1:
                    logLevelString = "DEBUG";
                    break;
                case 2:
                    logLevelString = "INFO";
                    break;
                case 3:
                    logLevelString = "WARNING";
                    break;
                case 4:
                    logLevelString = "ERROR";
                    break;
                case 5:
                    logLevelString = "CRITICAL";
                    break;
                default:
                    logLevelString = "UNKNOWN";
                    break;
            }

            // Build output string
            string outLine = $"{logLevelString} [{GetDateString()}] : {msg}";
            WriteToLogFile(outLine);
        }

        // Timestamp for log line
        private string GetDateString()
        {
            DateTime timeNow = DateTime.Now;
            string timeNowString = timeNow.ToString("dd/MM/yyyy HH:mm:ss");
            return timeNowString;
        }

        // Write output string to the specified file
        // should be found under bin/debug directory
        private void WriteToLogFile(string outString)
        {
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

