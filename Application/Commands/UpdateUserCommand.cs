using Application.DTOs;
using MediatR;

namespace Application.Commands;

public record UpdateUserCommand(
    string Id,
    string FirstName,
    string LastName,
    string NationalCode,
    DateTime BirthDate
) : IRequest<UserDto>;
