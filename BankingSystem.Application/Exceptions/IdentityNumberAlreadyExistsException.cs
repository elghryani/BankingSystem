using System;
using System.Collections.Generic;
using System.Text;

namespace BankingSystem.Application.Exceptions
{
    public class IdentityNumberAlreadyExistsException : Exception
    {
        public IdentityNumberAlreadyExistsException()
            : base("Identity number already exists.")
        { }
    }
}
