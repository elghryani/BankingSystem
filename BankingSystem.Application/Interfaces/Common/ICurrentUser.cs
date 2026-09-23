
using System;
using System.Collections.Generic;
using System.Text;

namespace BankingSystem.Application.Interfaces.Common
{
    public interface ICurrentUser
    {
        Guid EmployeeId { get; }
    }
}
