using MediatR;

namespace BankingSystem.Application.Features.Employee.Commands.CreateEmployee
{
    public record CreateEmployeeCommand(string UserName,
        string? Email,
        string Password,
        string PhoneNumber) : IRequest<Guid>;
}
