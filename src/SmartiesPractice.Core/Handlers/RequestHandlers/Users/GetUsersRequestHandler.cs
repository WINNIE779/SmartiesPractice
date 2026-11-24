using Mediator.Net.Context;
using Mediator.Net.Contracts;
using SmartiesPractice.Core.Services.Users;
using SmartiesPractice.Messages.Requests.Users;

namespace SmartiesPractice.Core.Handlers.RequestHandlers.Users;

public class GetUsersRequestHandler : IRequestHandler<GetUsersRequest, GetUsersResponse>
{
    private readonly UserService _userService;

    public GetUsersRequestHandler(UserService userService)
    {
        _userService = userService;
    }

    public async Task<GetUsersResponse> Handle(
        IReceiveContext<GetUsersRequest> context,
        CancellationToken cancellationToken)
    {
        var users = await _userService.GetAllAsync(cancellationToken);
        return new GetUsersResponse(users);
    }
}
