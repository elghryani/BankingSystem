using MediatR;
using BankingSystem.Application.Interfaces;

namespace BankingSystem.Application.Features.Customers.Queries.GetPendingCustomers
{
    public class GetPendingCustomersQueryHandler : IRequestHandler<GetPendingCustomersQuery, List<GetPendingCustomersResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetPendingCustomersQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetPendingCustomersResponse>> Handle(GetPendingCustomersQuery request, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.CustomerRepository.GetPendingCustomersAsync();

            return customer;
        }
      
    }
}