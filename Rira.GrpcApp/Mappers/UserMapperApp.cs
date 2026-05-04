using Application.Commands;
using Application.DTOs;
using Azure.Core;
using Domain.Entities;
using Google.Protobuf.WellKnownTypes;
using MediatR;
using Rira.GrpcApp;

namespace Application.Mappers;

public sealed class UserMapperApp
{
    public CreateUserCommand Map(CreateUserRequest request)
    {
        return new CreateUserCommand(
            request.FirstName,
            request.LastName,
            request.NationalCode,
            request.BirthDate.ToDateTime()
        );
    }

    public UserResponse Map(UserDto dto)
    {
        return new UserResponse
        {
            Id = dto.Id,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            NationalCode = dto.NationalCode,
            BirthDate = Timestamp.FromDateTime(DateTime.SpecifyKind(dto.BirthDate, DateTimeKind.Utc))
        };
    }

    public UpdateUserCommand Map(UpdateUserRequest request)
    {
        return new UpdateUserCommand(
            request.Id,
            request.FirstName,
            request.LastName,
            request.NationalCode,
            request.BirthDate.ToDateTime()
        );
    }

}
