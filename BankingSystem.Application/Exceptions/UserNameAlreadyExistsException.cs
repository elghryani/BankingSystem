namespace BankingSystem.Application.Exceptions
{
    public class UserNameAlreadyExistsException : Exception
    {
        public UserNameAlreadyExistsException(string userName)
            : base($"Username '{userName}' already exists.") 
        { }
    }
}
