
namespace BankingSystem.Application.Exceptions
{
    public class NotFoundException(string entyity, object id) : Exception($"the {entyity} with id: {id} not found");
    
}
