using BankingSystem.Application.Interfaces;
using MediatR;
using BankingSystem.Application.Exceptions;
using BankingSystem.Application.Interfaces.Common;
namespace BankingSystem.Application.Features.Auth.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenService _tokenService;
        private readonly IPasswordHasher _passwordHasher;
        public LoginCommandHandler(IUnitOfWork unitOfWork,IPasswordHasher passwordHasher, ITokenService tokenService)
        {
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
        }
        public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var employee =await _unitOfWork.EmployeeRepository.FindByUserNameAsync(request.userName);

            if(employee == null) 
                throw new NotFoundException(request.userName,null);

            if (!_passwordHasher.Verify(request.password,employee.Password))
            {
                throw new NotFoundException(request.userName, null);
            }

            var token = _tokenService.GenerateToken(employee.Id, employee.UserName);

            return new LoginResponse(employee.UserName,employee.PhoneNumber,employee.Status,token);



        }
    }
}
