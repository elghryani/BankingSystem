using System;
using System.Collections.Generic;
using System.Text;

namespace BankingSystem.Application.Exceptions
{
    public class CustomerPhoneAlreadyExistsException : Exception
    {
        public CustomerPhoneAlreadyExistsException(string phoneNumber) : base($"Phone number '{phoneNumber}' already exists.")
        { }
    }
}
