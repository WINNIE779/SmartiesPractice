using Mediator.Net.Contracts;

namespace SmartiesPractice.Messages.Users;

public record GetUsersRequest : IRequest;

public record GetUsersResponse(List<User> Users) : IResponse;
