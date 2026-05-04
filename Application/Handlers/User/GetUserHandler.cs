using Application.DTOs;
using Application.Mappers;
using Application.Queries;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers.User;

public class GetUserHandler(IUserRepository repository, UserMapper mapper) : IRequestHandler<GetUserQuery, UserDto?>
{

    public async Task<UserDto?> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await repository.GetById(Guid.Parse(request.Id), cancellationToken);

        if (user == null)
            return null;

        return mapper.Map(user);
    }
}
