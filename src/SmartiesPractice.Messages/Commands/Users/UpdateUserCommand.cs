using Mediator.Net.Contracts;
using SmartiesPractice.Messages.DTO.Users;

namespace SmartiesPractice.Messages.Commands.Users;

public record UpdateUserCommand(int Id, UpdateUserRequestDto Request) : ICommand;

public record UpdateUserResponse(UserDto? User) : IResponse;
