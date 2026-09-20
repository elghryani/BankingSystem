using System;
using System.Collections.Generic;
using System.Text;

namespace BankingSystem.Application.Features.Accounts.Commands.CreateAccount
{
    public record CreateAccountResponse(Guid id,string accountNumber,decimal balance,string status,DateTime createdAt);
    
    
}
