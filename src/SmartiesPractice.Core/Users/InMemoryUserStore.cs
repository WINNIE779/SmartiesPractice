using SmartiesPractice.Messages.Users;

namespace SmartiesPractice.Core.Users;

public class InMemoryUserStore
{
    private readonly List<User> _users = new();
    private int _nextId = 1;

    public User Add(User user)
    {
        user.Id = _nextId++;
        _users.Add(user);
        return user;
    }

    public List<User> GetAll()
    {
        return _users;
    }

    public User? GetById(int id)
    {
        return _users.FirstOrDefault(user => user.Id == id);
    }

    public User? Update(int id, User updatedUser)
    {
        var user = GetById(id);

        if (user is null)
        {
            return null;
        }

        user.Name = updatedUser.Name;
        user.Age = updatedUser.Age;

        return user;
    }

    public bool Delete(int id)
    {
        var user = GetById(id);

        if (user is null)
        {
            return false;
        }

        _users.Remove(user);
        return true;
    }
}