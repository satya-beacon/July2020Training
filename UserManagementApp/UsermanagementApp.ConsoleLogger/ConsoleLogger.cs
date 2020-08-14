using System;
using UsermanagementApp.Contracts;

namespace UsermanagementApp.ConsoleLog
{
    public class ConsoleLogger : ILogger
    {
        public void LogError(string message)
        {
            Console.WriteLine($"The error is: {message}");
        }

        public void LogInfo(string message)
        {
            Console.WriteLine($"The Information is : {message}");
        }

        public void LogWarning(string message)
        {
            Console.WriteLine($"The Warning is : {message}");
        }
    }
}
