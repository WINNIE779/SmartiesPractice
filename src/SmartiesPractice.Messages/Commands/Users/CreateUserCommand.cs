using Mediator.Net.Contracts;
using SmartiesPractice.Messages.DTO.Users;

namespace SmartiesPractice.Messages.Commands.Users;

public class CreateUserCommand : ICommand
{
    public string Name { get; set; } = string.Empty;

    public int Age { get; set; }
}

public record CreateUserResponse(UserDto User) : IResponse;
