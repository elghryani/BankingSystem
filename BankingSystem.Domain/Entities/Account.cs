using BankingSystem.Domain.Enums;

namespace BankingSystem.Domain.Entities
{
    public sealed class Account
    {
        public Guid Id { get;private set; }
        public Guid CustomerId { get; private set; }
        public string AccountNumber { get; private set; } = null!;
        public decimal Balance { get; private set; } 
        public EnAccountStatus Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public Customer Customer { get; private set; }

        private Account() { }
        public static Account Create(Guid customerId,string accountNumber, decimal balance = 0m)
        {
            if (balance < 0)
                throw new ArgumentOutOfRangeException();

            return new Account()
            {
                CustomerId = customerId,
                AccountNumber = accountNumber,
                Balance = balance,
                Status = EnAccountStatus.Active,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = null
            };
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException("Deposit amount must be greater than zero.");

            if (Status != EnAccountStatus.Active)
                throw new InvalidOperationException("Cannot deposit into an inactive account.");

            Balance += amount;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException("Withdraw amount must be greater than zero.");

            if (amount > Balance)
                throw new InvalidOperationException();

            if (Status != EnAccountStatus.Active)
                throw new InvalidOperationException("Cannot deposit into an inactive account.");

            Balance -= amount;
        }


    }
}
