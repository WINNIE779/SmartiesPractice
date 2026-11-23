using SmartiesPractice.Messages.Users;

namespace SmartiesPractice.Core.Users;

public class UserService
{
    private readonly InMemoryUserStore _store;

    public UserService(InMemoryUserStore store)
    {
        _store = store;
    }

    public Task<User> CreateAsync(
        CreateUserCommand command, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var user = new User
        {
            Name = command.Name,
            Age = command.Age
        };

        return Task.FromResult(_store.Add(user));
    }

    public Task<List<User>> GetAllAsync(CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return Task.FromResult(_store.GetAll());
    }

    public Task<User?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return Task.FromResult(_store.GetById(id));
    }

    public Task<User?> UpdateAsync(
        int id, UpdateUserRequest request, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var updatedUser = new User
        {
            Name = request.Name,
            Age = request.Age
        };

        return Task.FromResult(_store.Update(id, updatedUser));
    }

    public Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return Task.FromResult(_store.Delete(id));
    }
}
