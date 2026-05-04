using Application.Commands;
using Application.DTOs;
using Domain.Entities;

namespace Application.Mappers;

public sealed class UserMapper
{
    public User Map(CreateUserCommand command)
    {
        return new User(command.FirstName, command.LastName, command.NationalCode, command.BirthDate);
    }

    public UserDto Map(User user)
    {
        return new UserDto(
            user.Id.ToString(),
            user.FirstName,
            user.LastName,
            user.NationalCode,
            user.BirthDate
        );
    }

    public User Map(UpdateUserCommand command, User user)
    {
        user.Update(command.FirstName, command.LastName, command.NationalCode, command.BirthDate);
        return user;
    }

    public List<UserDto> Map(IEnumerable<User> users)
    {
        return users.Select(p => new UserDto(
            p.Id.ToString(),
            p.FirstName,
            p.LastName,
            p.NationalCode,
            p.BirthDate
        )).ToList();
    }
}
