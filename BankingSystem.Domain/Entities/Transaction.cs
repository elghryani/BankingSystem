using BankingSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankingSystem.Domain.Entities
{
    public sealed class Transaction
    {
        public Guid Id { get;private set; }
        public Guid EmployeeId { get;private set; }
        public Guid? FromAccountId { get;private set; }
        public Guid? ToAccountId { get;private set; }
        public decimal Amount { get;private set; }
        public EnTransactionTypes TransactionTypes { get; private set; }
        public EnTransactionStatus Status { get; private set; }
        public DateTime CreatedAt { get;private set; }


        private Transaction() { }

        
        

        public static Transaction Create(Guid employeeId ,decimal amount, EnTransactionTypes transactionTypes, Guid? fromAccountId = null,Guid? toAccountId = null)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException();

           
            if(transactionTypes == EnTransactionTypes.Transfer)
            {
                if (!fromAccountId.HasValue || !toAccountId.HasValue)
                    throw new ArgumentNullException();
                
            }
            if(transactionTypes == EnTransactionTypes.Deposit)
            {
                if(fromAccountId.HasValue)
                    throw new ArgumentOutOfRangeException();

                if(!toAccountId.HasValue)
                    throw new ArgumentNullException();
            }


            return new Transaction()
            {
                EmployeeId = employeeId,
                Amount = amount,
                TransactionTypes = transactionTypes,
                Status = EnTransactionStatus.Pending,
                CreatedAt = DateTime.UtcNow,
                FromAccountId = fromAccountId,
                ToAccountId = toAccountId

            };
        }

    }
}
