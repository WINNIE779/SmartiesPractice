using Mediator.Net.Context;
using Mediator.Net.Contracts;
using SmartiesPractice.Core.Users;
using SmartiesPractice.Messages.Users;

namespace SmartiesPractice.Core.Handlers.CommandHandlers.Users;

public class UpdateUserCommandHandler : ICommandHandler<UpdateUserCommand, UpdateUserResponse>
{
    private readonly UserService _userService;

    public UpdateUserCommandHandler(UserService userService)
    {
        _userService = userService;
    }

    public async Task<UpdateUserResponse> Handle(
        IReceiveContext<UpdateUserCommand> context,
        CancellationToken cancellationToken)
    {
        var user = await _userService.UpdateAsync(context.Message.Id, context.Message.Request, cancellationToken);
        return new UpdateUserResponse(user);
    }
}
