using BankingSystem.Application.Exceptions;
using BankingSystem.Application.Interfaces;
using MediatR;
namespace BankingSystem.Application.Features.Employee.Commands.CreateEmployee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateEmployeeCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            if(await _unitOfWork.EmployeeRepository.ExistsByUserNameAsync(request.UserName))
            {
                throw new UserNameAlreadyExistsException(request.UserName);
            }
            if(await _unitOfWork.EmployeeRepository.ExistsByPhoneNumberAsync(request.PhoneNumber))
            {
                throw new PhoneNumberAlreadyExistsException(request.PhoneNumber);
            }

            var newEmployee = Domain.Entities.Employee.Create(request.UserName,
                request.Email,
                request.Password,
                request.PhoneNumber);

            await _unitOfWork.EmployeeRepository.AddAsync(newEmployee);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return newEmployee.Id;


        }
    }
}
