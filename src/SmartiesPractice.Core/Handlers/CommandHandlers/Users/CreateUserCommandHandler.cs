using Mediator.Net.Context;
using Mediator.Net.Contracts;
using SmartiesPractice.Core.Services.Users;
using SmartiesPractice.Messages.Commands.Users;

namespace SmartiesPractice.Core.Handlers.CommandHandlers.Users;

public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, CreateUserResponse>
{
    private readonly UserService _userService;

    public CreateUserCommandHandler(UserService userService)
    {
        _userService = userService;
    }

    public async Task<CreateUserResponse> Handle(
        IReceiveContext<CreateUserCommand> context,
        CancellationToken cancellationToken)
    {
        var user = await _userService.CreateAsync(context.Message, cancellationToken);
        return new CreateUserResponse(user);
    }
}
