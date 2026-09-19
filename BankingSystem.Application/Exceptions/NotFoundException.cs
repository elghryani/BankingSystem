
namespace BankingSystem.Application.Exceptions
{
    public class NotFoundException<T> : Exception
    {
        public NotFoundException(Guid id)
            : base($"{typeof(T).Name} with ID '{id}' was not found.")
        {
        }
    }
}
