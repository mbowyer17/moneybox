using Moneybox.App.DataAccess;
using Moneybox.App.Domain.Services;
using System;

namespace Moneybox.App.Features
{
    public class WithdrawMoney
    {
        private IAccountRepository accountRepository;
        private INotificationService notificationService;

        public WithdrawMoney(IAccountRepository accountRepository, INotificationService notificationService)
        {
            this.accountRepository = accountRepository;
            this.notificationService = notificationService;
        }

        public void Execute(Guid fromAccountId, decimal amount)
        {
            // TODO:
            var from = this.accountRepository.GetAccountById(fromAccountId);


            // Calculate the Transaction
            from.Withdraw(amount);

            // Checked the balance
            if (from.IsLowBalance())
                this.notificationService.NotifyFundsLow(from.User.Email);

            // Update the account 
            this.accountRepository.Update(from);

        }
    }
}
