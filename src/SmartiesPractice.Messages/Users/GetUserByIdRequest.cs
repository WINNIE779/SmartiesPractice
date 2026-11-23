using Mediator.Net.Contracts;

namespace SmartiesPractice.Messages.Users;

public record GetUserByIdRequest(int Id) : IRequest;

public record GetUserByIdResponse(User? User) : IResponse;
