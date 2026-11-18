using SmartiesPractice.Messages.Users;

namespace SmartiesPractice.Core.Users;

public class UserService
{
    private readonly InMemoryUserStore _store;

    public UserService(InMemoryUserStore store)
    {
        _store = store;
    }

    public User Create(CreateUserRequest request)
    {
        var user = new User
        {
            Name = request.Name,
            Age = request.Age
        };

        return _store.Add(user);
    }

    public List<User> GetAll()
    {
        return _store.GetAll();
    }

    public User? GetById(int id)
    {
        return _store.GetById(id);
    }

    public User? Update(int id, UpdateUserRequest request)
    {
        var updatedUser = new User
        {
            Name = request.Name,
            Age = request.Age
        };

        return _store.Update(id, updatedUser);
    }

    public bool Delete(int id)
    {
        return _store.Delete(id);
    }
}