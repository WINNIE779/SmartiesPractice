using Mediator.Net.Contracts;
using SmartiesPractice.Messages.DTO.Users;

namespace SmartiesPractice.Messages.Requests.Users;

public record GetUserByIdRequest(int Id) : IRequest;

public record GetUserByIdResponse(UserDto? User) : IResponse;
