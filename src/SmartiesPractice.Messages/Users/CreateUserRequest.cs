using Mediator.Net.Contracts;

namespace SmartiesPractice.Messages.Users;

public class CreateUserRequest : IRequest
{
    public string Name { get; set; } = string.Empty;

    public int Age { get; set; }
}