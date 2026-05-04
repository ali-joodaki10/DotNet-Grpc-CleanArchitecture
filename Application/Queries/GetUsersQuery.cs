using Application.DTOs;
using MediatR;
using System;

namespace Application.Queries;

public record GetUsersQuery(int PageNumber = 1, int PageSize = 10) : IRequest<List<UserDto>>;
