using BankingSystem.Application.Exceptions;
using BankingSystem.Application.Interfaces;
using BankingSystem.Application.Interfaces.Common;
using MediatR;
namespace BankingSystem.Application.Features.Employee.Commands.CreateEmployee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher _passwordHasher;
        public CreateEmployeeCommandHandler(IUnitOfWork unitOfWork,IPasswordHasher passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
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
                _passwordHasher.Hash(request.Password),
                request.PhoneNumber);

            await _unitOfWork.EmployeeRepository.AddAsync(newEmployee);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return newEmployee.Id;


        }
    }
}
