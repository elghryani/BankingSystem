using BankingSystem.Domain.Enums;

namespace BankingSystem.Domain.Entities
{
    public sealed class Employee
    {
        public Guid Id { get;private set; }
        public string UserName { get; private set; } = null!;
        public string? Email { get; private set; }
        public string Password { get; private set; } = null!;
        public string PhoneNumber { get; private set; } = null!;
        public EnUserStatus Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        private Employee () { }

        public static Employee Create(string userName,string? email,string password,string phoneNumber)
        {
            return new Employee()
            {
                Id = Guid.NewGuid(),
                UserName = userName,
                Email = email,
                Password = password,
                PhoneNumber = phoneNumber,
                Status = EnUserStatus.Active,
                CreatedAt = DateTime.UtcNow,
            };
        }

        public void Update(string userName, string? email, string phoneNumber)
        {
            UserName = userName;
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
