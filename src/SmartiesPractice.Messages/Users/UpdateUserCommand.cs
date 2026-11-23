using Mediator.Net.Contracts;

namespace SmartiesPractice.Messages.Users;

public record UpdateUserCommand(int Id, UpdateUserRequest Request) : ICommand;

public record UpdateUserResponse(User? User) : IResponse;
