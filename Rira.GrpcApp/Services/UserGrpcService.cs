using Application.Commands;
using Application.Mappers;
using Application.Queries;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MediatR;

namespace Rira.GrpcApp.Services;

public class UserGrpcService(IMediator mediator, UserMapperApp mapper) : UserService.UserServiceBase
{
    public override async Task<UserResponse> CreateUser(CreateUserRequest request, ServerCallContext context)
    {
        var mapped = mapper.Map(request);

        var result = await mediator.Send(mapped);

        return mapper.Map(result);
    }

    public override async Task<UserResponse?> GetUser(GetUserRequest request, ServerCallContext context)
    {
        var query = new GetUserQuery(request.Id);
        var result = await mediator.Send(query);

        if (result != null)
            return mapper.Map(result);

        return null;
    }

    public override async Task<UserListResponse> GetAllUsers(GetAllUsersRequest request, ServerCallContext context)
    {
        var query = new GetUsersQuery();
        var results = await mediator.Send(query);

        var response = new UserListResponse();
        foreach (var user in results)
        {
            response.Users.Add(new UserResponse
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                NationalCode = user.NationalCode,
                BirthDate = Timestamp.FromDateTime(DateTime.SpecifyKind(user.BirthDate, DateTimeKind.Utc))
            });
        }

        return response;
    }

    public override async Task<UserResponse> UpdateUser(UpdateUserRequest request, ServerCallContext context)
    {
        var mapped = mapper.Map(request);

        var result = await mediator.Send(mapped);

        return mapper.Map(result);

    }

    public override async Task<DeleteUserResponse> DeleteUser(DeleteUserRequest request, ServerCallContext context)
    {
        var command = new DeleteUserCommand(request.Id);
        await mediator.Send(command);

        return new DeleteUserResponse
        {
            Success = true,
        };
    }
}
