using MediatR;

namespace Application.Commands;

public record DeleteUserCommand(string Id) : IRequest<bool>;
