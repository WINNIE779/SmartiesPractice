using SmartiesPractice.Messages.Commands.Users;
using SmartiesPractice.Messages.DTO.Users;

namespace SmartiesPractice.Core.Services.Users;

public class UserService
{
    private readonly UserDataProvider _userDataProvider;

    public UserService(UserDataProvider userDataProvider)
    {
        _userDataProvider = userDataProvider;
    }

    public Task<UserDto> CreateAsync(
        CreateUserCommand command, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var user = new UserDto
        {
            Name = command.Name,
            Age = command.Age
        };

        return Task.FromResult(_userDataProvider.Add(user));
    }

    public Task<List<UserDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return Task.FromResult(_userDataProvider.GetAll());
    }

    public Task<UserDto?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return Task.FromResult(_userDataProvider.GetById(id));
    }

    public Task<UserDto?> UpdateAsync(
        int id, UpdateUserRequestDto request, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var updatedUser = new UserDto
        {
            Name = request.Name,
            Age = request.Age
        };

        return Task.FromResult(_userDataProvider.Update(id, updatedUser));
    }

    public Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return Task.FromResult(_userDataProvider.Delete(id));
    }
}
