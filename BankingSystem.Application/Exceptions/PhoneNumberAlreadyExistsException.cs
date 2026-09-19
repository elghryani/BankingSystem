using System;
using System.Collections.Generic;
using System.Text;

namespace BankingSystem.Application.Exceptions
{
    public class PhoneNumberAlreadyExistsException : Exception
    {
        public PhoneNumberAlreadyExistsException(string phoneNumber) : base($"Phone number '{phoneNumber}' already exists.")
        { }
    }
}
