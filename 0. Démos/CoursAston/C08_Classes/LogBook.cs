using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C08_Classes
{
    public interface ILogger
    {
        public int LogSeverity { get; set; }
        public string LogType { get; set; }
        void Log(string message);
        bool LogToDb(string message);
        bool LogBalanceAfterWithdrawal(decimal balanceAfter);
        string MessageWithReturnStr(string message);
        bool LogWithOutputResult(string str, out string outputStr);
        bool LogWithCustomerRef(ref Customer customer);
    }
    public class LogBook : ILogger
    {
        public int LogSeverity { get; set; }
        public string LogType { get; set; }
        public void Log(string message)
        {
            Console.WriteLine(message);
        }

        public bool LogBalanceAfterWithdrawal(decimal balanceAfter)
        {
            if (balanceAfter >= 0)
            {
                Console.WriteLine("Success");
                return true;
            }

            Console.WriteLine("Failure");
            return false;
        }

        public bool LogToDb(string message)
        {
            Console.WriteLine(message);
            return true;
        }

        public bool LogWithCustomerRef(ref Customer customer)
        {
            return true;
        }

        public bool LogWithOutputResult(string str, out string outputStr)
        {
            outputStr = "Hello " + str;
            return true;
        }

        public string MessageWithReturnStr(string message)
        {
            Console.WriteLine(message);
            return message.ToLower();
        }
    }

    //public class LogFakker : ILogger
    //{
    //    public void Log(string message)
    //    {
    //    }
    //}
}
