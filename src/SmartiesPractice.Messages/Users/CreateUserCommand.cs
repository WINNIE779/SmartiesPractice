using Mediator.Net.Contracts;

namespace SmartiesPractice.Messages.Users;

public class CreateUserCommand : ICommand
{
    public string Name { get; set; } = string.Empty;

    public int Age { get; set; }
}

public record CreateUserResponse(User User) : IResponse;
