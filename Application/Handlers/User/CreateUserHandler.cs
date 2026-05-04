using Application.Commands;
using Application.DTOs;
using Application.Mappers;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers.User;

public class CreateUserHandler(IUserRepository repository, UserMapper mapper) : IRequestHandler<CreateUserCommand, UserDto>
{
    public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var mappedUser = mapper.Map(request);

        var createdUser = await repository.Create(mappedUser, cancellationToken);

        return mapper.Map(createdUser);
    }
}
