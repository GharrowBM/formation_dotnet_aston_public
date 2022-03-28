using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C08_Classes
{
    public class BankAccount
    {
        private decimal _balance;
        private readonly ILogger _logger;
        public decimal Balance { get { return _balance; } }
        public BankAccount(ILogger logger)
        {
            _logger = logger;
            _balance = 0;
        }

        public bool Deposit(decimal amount)
        {
            _logger.Log("Deposit Inviked");
            _logger.Log("Test");
            _logger.LogSeverity = 101;
            var temp = _logger.LogSeverity;
            _balance += amount;

            return true;
        }

        public bool WithDrawal(decimal amount)
        {
            if (_balance - amount >= 0)
            {
                _logger.LogToDb($"Logging to Database : {amount}");
                _balance -= amount;
                return _logger.LogBalanceAfterWithdrawal(_balance);
            }

            return _logger.LogBalanceAfterWithdrawal(_balance - amount);
        }

    }
}
