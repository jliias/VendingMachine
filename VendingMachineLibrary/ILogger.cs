// Interface for Logger

namespace VendingMachineLibrary
{
    interface ILogger
    {
        void LogInformation(string msg);
        void LogWarning(string msg);
        void LogError(string msg);
    }
}
