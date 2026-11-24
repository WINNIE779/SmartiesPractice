using SmartiesPractice.Messages.DTO.Users;

namespace SmartiesPractice.Core.Services.Users;

public class UserDataProvider
{
    private readonly List<UserDto> _users = new();
    private int _nextId = 1;

    public UserDto Add(UserDto user)
    {
        user.Id = _nextId++;
        _users.Add(user);
        return user;
    }

    public List<UserDto> GetAll()
    {
        return _users;
    }

    public UserDto? GetById(int id)
    {
        return _users.FirstOrDefault(user => user.Id == id);
    }

    public UserDto? Update(int id, UserDto updatedUser)
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
