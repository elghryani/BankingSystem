using BankingSystem.Application.Interfaces;
using BankingSystem.Application.Interfaces.Common;
using MediatR;
using BankingSystem.Application.Exceptions;

namespace BankingSystem.Application.Features.Auth.Queries.GetCurrentUser
{
    public class GetCurrentUserQueryHandler : IRequestHandler<GetCurrentUserQuery, CurrentUserResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUser _currentUser;
        public GetCurrentUserQueryHandler(IUnitOfWork unitOfWork,ICurrentUser currentUser)
        {
            _unitOfWork = unitOfWork;
            _currentUser = currentUser;
        }
        public async Task<CurrentUserResponse> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken)
        {

            var user =await _unitOfWork.EmployeeRepository.GetByIdAsync(_currentUser.EmployeeId, cancellationToken);

            if(user == null)
                throw new NotFoundException("user",_currentUser.EmployeeId);

            return new CurrentUserResponse
            (
                user.Id,
                user.UserName,
                user.PhoneNumber,
                user.Status.ToString() 
            );
        }
    }
}
