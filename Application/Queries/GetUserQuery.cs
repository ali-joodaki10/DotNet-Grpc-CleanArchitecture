using Application.DTOs;
using MediatR;

namespace Application.Queries;

public record GetUserQuery(string Id) : IRequest<UserDto?>;

