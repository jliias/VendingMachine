// Author: Juha Liias 2021 
//  Use at your own risk!

namespace VendingMachineLibrary
{
    interface ILogger
    {
        void LogInformation(string msg);
        void LogWarning(string msg);
        void LogError(string msg);
    }
}
