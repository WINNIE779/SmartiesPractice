using Mediator.Net.Contracts;
using SmartiesPractice.Messages.DTO.Users;

namespace SmartiesPractice.Messages.Requests.Users;

public record GetUsersRequest : IRequest;

public record GetUsersResponse(List<UserDto> Users) : IResponse;
