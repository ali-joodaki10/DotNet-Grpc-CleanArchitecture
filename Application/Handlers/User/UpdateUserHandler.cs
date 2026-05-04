using Application.Commands;
using Application.DTOs;
using Application.Mappers;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers.User;

public class UpdateUserHandler(IUserRepository repository, UserMapper mapper) : IRequestHandler<UpdateUserCommand, UserDto>
{

    public async Task<UserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await repository.GetById(Guid.Parse(request.Id), cancellationToken) ?? throw new Exception($"User with ID {request.Id} not found");

        var mappedUser = mapper.Map(request, user);

        var updatedUser = await repository.Update(mappedUser, cancellationToken);

        return mapper.Map(updatedUser);

    }
}
