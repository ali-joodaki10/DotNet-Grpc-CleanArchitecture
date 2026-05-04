using Application.DTOs;
using MediatR;

namespace Application.Commands;

public record CreateUserCommand(
    string FirstName,
    string LastName,
    string NationalCode,
    DateTime BirthDate
) : IRequest<UserDto>;
