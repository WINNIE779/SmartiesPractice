using Mediator.Net.Context;
using Mediator.Net.Contracts;
using SmartiesPractice.Core.Users;
using SmartiesPractice.Messages.Users;

namespace SmartiesPractice.Core.Handlers.RequestHandlers.Users;

public class CreateUserRequestHandler
    : IRequestHandler<CreateUserRequest, CreateUserResponse>
{
    private readonly UserService _userService;

    public CreateUserRequestHandler(UserService userService)
    {
        _userService = userService;
    }

    public Task<CreateUserResponse> Handle(
        IReceiveContext<CreateUserRequest> context,
        CancellationToken cancellationToken)
    {
        var user = _userService.Create(context.Message);
        return Task.FromResult(new CreateUserResponse(user));
    }
}

public class GetUsersRequestHandler
    : IRequestHandler<GetUsersRequest, GetUsersResponse>
{
    private readonly UserService _userService;

    public GetUsersRequestHandler(UserService userService)
    {
        _userService = userService;
    }

    public Task<GetUsersResponse> Handle(
        IReceiveContext<GetUsersRequest> context,
        CancellationToken cancellationToken)
    {
        var users = _userService.GetAll();
        return Task.FromResult(new GetUsersResponse(users));
    }
}

public class GetUserByIdRequestHandler
    : IRequestHandler<GetUserByIdRequest, GetUserByIdResponse>
{
    private readonly UserService _userService;

    public GetUserByIdRequestHandler(UserService userService)
    {
        _userService = userService;
    }

    public Task<GetUserByIdResponse> Handle(
        IReceiveContext<GetUserByIdRequest> context,
        CancellationToken cancellationToken)
    {
        var user = _userService.GetById(context.Message.Id);
        return Task.FromResult(new GetUserByIdResponse(user));
    }
}

public class UpdateUserRequestHandler
    : IRequestHandler<UpdateUserMessage, UpdateUserResponse>
{
    private readonly UserService _userService;

    public UpdateUserRequestHandler(UserService userService)
    {
        _userService = userService;
    }

    public Task<UpdateUserResponse> Handle(
        IReceiveContext<UpdateUserMessage> context,
        CancellationToken cancellationToken)
    {
        var user = _userService.Update(context.Message.Id, context.Message.Request);
        return Task.FromResult(new UpdateUserResponse(user));
    }
}

public class DeleteUserRequestHandler
    : IRequestHandler<DeleteUserRequest, DeleteUserResponse>
{
    private readonly UserService _userService;

    public DeleteUserRequestHandler(UserService userService)
    {
        _userService = userService;
    }

    public Task<DeleteUserResponse> Handle(
        IReceiveContext<DeleteUserRequest> context,
        CancellationToken cancellationToken)
    {
        var deleted = _userService.Delete(context.Message.Id);
        return Task.FromResult(new DeleteUserResponse(deleted));
    }
}
