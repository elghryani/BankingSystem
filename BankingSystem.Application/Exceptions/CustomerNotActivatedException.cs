namespace BankingSystem.Application.Exceptions
{
    public class CustomerNotActivatedException : Exception
    {
        public CustomerNotActivatedException() : base("Cannot create account because the customer is not activated.")
        { }
        
    }
}
