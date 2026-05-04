using Application.Commands;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers.User;

public class DeleteUserHandler(IUserRepository repository) : IRequestHandler<DeleteUserCommand, bool>
{
    public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await repository.GetById(Guid.Parse(request.Id), cancellationToken);
        if (user == null)
            return false;

        await repository.Delete(Guid.Parse(request.Id), cancellationToken);

        return true;
    }
}
