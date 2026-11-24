using Mediator.Net.Context;
using Mediator.Net.Contracts;
using SmartiesPractice.Core.Services.Users;
using SmartiesPractice.Messages.Requests.Users;

namespace SmartiesPractice.Core.Handlers.RequestHandlers.Users;

public class GetUserByIdRequestHandler : IRequestHandler<GetUserByIdRequest, GetUserByIdResponse>
{
    private readonly UserService _userService;

    public GetUserByIdRequestHandler(UserService userService)
    {
        _userService = userService;
    }

    public async Task<GetUserByIdResponse> Handle(
        IReceiveContext<GetUserByIdRequest> context,
        CancellationToken cancellationToken)
    {
        var user = await _userService.GetByIdAsync(context.Message.Id, cancellationToken);
        return new GetUserByIdResponse(user);
    }
}
