using BankingSystem.Domain.Enums;
using System.Net.NetworkInformation;

namespace BankingSystem.Domain.Entities
{
    public sealed class Customer
    {
        public Guid Id { get;private set; }
        public string FirstName { get; private set; } = null!;
        public string LastName { get;private set; } = null!;
        public string? Email { get;private set; }
        public string PhoneNumber { get; private set; } = null!; 
        public EnUserStatus Status { get;private set; }
        public DateTime CreatedAt { get;private set; }
        public DateTime? UpdatedAt { get;private set; }

        public KycProfile? Profile { get; private set; }
        public ICollection<Account> Accounts { get; private set; } = new List<Account>();
        private Customer() { }
        public static Customer Create(string firstName,string lastName, string? email,string phoneNumber)
        {
            return new Customer()
            {
                Id = Guid.NewGuid(),
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber,
                Status = EnUserStatus.Pending,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = null
            };
        }

        public void AddKycProfile(string identityNumber, DateOnly dateOfBirth, string address, EnSourceOfIncome sourceOfIncome)
        {
            if (Profile != null)
                throw new InvalidOperationException("Customer already has a KYC profile.");

            Profile = KycProfile.Create(Id,identityNumber,dateOfBirth,address,sourceOfIncome);
        }

        public void UpdateKycProfile(string identityNumber, DateOnly dateOfBirth, string address, EnSourceOfIncome sourceOfIncome)
        {
            if (Profile == null)
                throw new InvalidOperationException("Customer does not have a KYC profile.");

            Profile.Update(identityNumber, dateOfBirth, address, sourceOfIncome);
        }
        public void Update(string firstName, string lastName, string? email, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Deactivate()
        {
            Status = EnUserStatus.InActive;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
