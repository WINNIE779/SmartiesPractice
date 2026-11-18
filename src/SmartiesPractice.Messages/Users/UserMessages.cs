using Mediator.Net.Contracts;

namespace SmartiesPractice.Messages.Users;

public record CreateUserResponse(User User) : IResponse;

public record GetUsersRequest : IRequest;

public record GetUsersResponse(List<User> Users) : IResponse;

public record GetUserByIdRequest(int Id) : IRequest;

public record GetUserByIdResponse(User? User) : IResponse;

public record UpdateUserMessage(int Id, UpdateUserRequest Request) : IRequest;

public record UpdateUserResponse(User? User) : IResponse;

public record DeleteUserRequest(int Id) : IRequest;

public record DeleteUserResponse(bool Deleted) : IResponse;
