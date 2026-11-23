using Mediator.Net.Context;
using Mediator.Net.Contracts;
using SmartiesPractice.Core.Users;
using SmartiesPractice.Messages.Users;

namespace SmartiesPractice.Core.Handlers.CommandHandlers.Users;

public class DeleteUserCommandHandler : ICommandHandler<DeleteUserCommand, DeleteUserResponse>
{
    private readonly UserService _userService;

    public DeleteUserCommandHandler(UserService userService)
    {
        _userService = userService;
    }

    public async Task<DeleteUserResponse> Handle(
        IReceiveContext<DeleteUserCommand> context,
        CancellationToken cancellationToken)
    {
        var deleted = await _userService.DeleteAsync(context.Message.Id, cancellationToken);
        return new DeleteUserResponse(deleted);
    }
}
