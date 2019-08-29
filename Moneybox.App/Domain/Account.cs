using System;

namespace Moneybox.App
{
    public class Account
    {
        public const decimal PayInLimit = 4000m;
        public const decimal WithdrawLimit = 0m;
        public const decimal LowBalance = 500m;

        public Guid Id { get; set; }

        public User User { get; set; }

        public decimal Balance { get; set; }

        public decimal Withdrawn { get; set; }

        public decimal PaidIn { get; set; }


        public void Withdraw(decimal amount)
        {
            // Checks if there is enough money to make a withdraw
            if (!canWithdraw(amount))
                throw new InvalidOperationException("Insufficient funds to make transfer");

            // Calculates the Transaction
            this.Balance = this.Balance - amount;
            this.Withdrawn = this.Withdrawn - amount;
        }

        public bool canWithdraw(decimal amount)
        {

            var newBalance = this.Balance - amount;
            return newBalance >= WithdrawLimit;
        }

        public bool BalanceLowAfterWithdraw (decimal amount)
        {
            var newBalance = this.Balance - amount;
            return newBalance <= LowBalance;
        }

        public bool IsLowBalance()
        {
            return BalanceLowAfterWithdraw(0);
        }
    }
}
