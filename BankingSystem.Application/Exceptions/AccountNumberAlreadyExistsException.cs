using System;
using System.Collections.Generic;
using System.Text;

namespace BankingSystem.Application.Exceptions
{
    public class AccountNumberAlreadyExistsException : Exception
    {
        public AccountNumberAlreadyExistsException() : base()
        { }
    }
}
