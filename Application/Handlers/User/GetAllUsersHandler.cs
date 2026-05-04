using Application.DTOs;
using Application.Mappers;
using Application.Queries;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers.User;

public class GetAllUsersHandler(IUserRepository repository, UserMapper mapper) : IRequestHandler<GetUsersQuery, List<UserDto>>
{
    public async Task<List<UserDto>> Handle(GetUsersQuery query, CancellationToken cancellationToken)
    {
        var users = await repository.GetAll(query.PageNumber, query.PageSize, cancellationToken);

        return mapper.Map(users);

    }
}