using System;

namespace Moneybox.App
{
    public class Account
    {
        public const decimal PayInLimit = 4000m;
        public const decimal WithdrawLimit = 0m;
       

        public Guid Id { get; set; }

        public User User { get; set; }

        public decimal Balance { get; set; }

        public decimal Withdrawn { get; set; }

        public decimal PaidIn { get; set; }


        public void Withdraw(decimal amount)
        {
            // Checks if there is enough money to make a withdraw
            if (!CanWithdraw(amount))
                throw new InvalidOperationException("Insufficient funds to make transfer");

            // Calculates the Transaction
            this.Balance = this.Balance - amount;
            this.Withdrawn = this.Withdrawn - amount;
        }

        public bool CanWithdraw(decimal amount)
        {

            var newBalance = this.Balance - amount;
            return newBalance >= WithdrawLimit;
        }

        
    }
}
