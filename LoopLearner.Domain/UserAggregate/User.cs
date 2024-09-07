using LoopLearner.Domain.Common;
using LoopLearner.Domain.UserAggregate.ValueObjects;

namespace LoopLearner.Domain.UserAggregate;

public class User : AggregateRoot<UserId>
{
    public UserId Id { get; private set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    private User() { } 
    private User(UserId id, string firstName, string lastName, string userName, string email, string password)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        UserName = userName;
        Email = email;
        Password = password;
    }
    public static User Create(UserId id, string firstName, string lastName, string userName, string email, string password) => new(id, firstName, lastName, userName, email, password);
    public static User CreateNew(string firstName, string lastName, string userName, string email, string password) => new(UserId.CreateNew(), firstName, lastName, userName, email, password);

    public void UpdatePassword(string password)
    {
        Password = password;
    }
}