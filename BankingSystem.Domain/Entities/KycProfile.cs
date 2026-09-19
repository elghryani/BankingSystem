using BankingSystem.Domain.Enums;

namespace BankingSystem.Domain.Entities
{
    public class KycProfile
    {
        public Guid Id { get;private set; }
        public Guid CustomerId { get; private set; }
        public string IdentityNumber { get; private set; }
        public DateOnly DateOfBirth { get; private set; }
        public string Address { get; private set; }
        public EnSourceOfIncome SourceOfIncome { get; private set; }
        public EnKYCStatus KYCStatus { get; private set; }
        public DateTime SubmittedAt { get; private set; }
        public DateTime VerifiedAt { get; private set; }

        public Customer Customer { get; private set; }


        private KycProfile() { }

        internal static KycProfile Create(Guid customerId,string identityNumber,DateOnly dateOfBirth,string address,EnSourceOfIncome sourceOfIncome)
        {
            return new KycProfile()
            {
                Id = Guid.NewGuid(),
                CustomerId = customerId,
                IdentityNumber = identityNumber,
                DateOfBirth = dateOfBirth,
                Address = address,
                SourceOfIncome = sourceOfIncome,
                KYCStatus = EnKYCStatus.Pending,
                SubmittedAt = DateTime.UtcNow
            };
        }

        internal void Update(string identityNumber, DateOnly dateOfBirth, string address, EnSourceOfIncome sourceOfIncome)
        {
            IdentityNumber = identityNumber;
            DateOfBirth = dateOfBirth;
            Address = address;
            SourceOfIncome = sourceOfIncome;
        }
    }
}
