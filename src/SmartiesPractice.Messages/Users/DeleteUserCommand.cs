using Mediator.Net.Contracts;

namespace SmartiesPractice.Messages.Users;

public record DeleteUserCommand(int Id) : ICommand;

public record DeleteUserResponse(bool Deleted) : IResponse;
