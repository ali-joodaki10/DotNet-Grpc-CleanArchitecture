using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using Rira.GrpcApp;

using Grpc.Net.Client;
using static Rira.GrpcApp.UserService;

GrpcChannel channel = GrpcChannel.ForAddress("https://localhost:44351/");
UserServiceClient client = new UserServiceClient(channel);

Console.WriteLine("=== CreateUser ===");
var createResponse = await client.CreateUserAsync(new CreateUserRequest
{
    FirstName = "ali",
    LastName = "joodaki",
    BirthDate = Timestamp.FromDateTime(DateTime.Parse("1997-08-18").ToUniversalTime()),
    NationalCode = "123456789"
});
Console.WriteLine($"create user: {createResponse.Id}");

Console.WriteLine("=== GetUser ===");

var getResponse = await client.GetUserAsync(new GetUserRequest
{
    Id = "E01B8491-3E60-408F-B06C-213CE8A05B8C"
});
Console.WriteLine($"full Name: {getResponse.FirstName} {getResponse.LastName}");


Console.WriteLine("===  GetAllUsers ===");
var allUsers = await client.GetAllUsersAsync(new GetAllUsersRequest());
foreach (var user in allUsers.Users)
{
    Console.WriteLine($"full Name: {user.FirstName} {user.LastName}\n");
}

Console.WriteLine("=== UpdateUser ===");
await client.UpdateUserAsync(new UpdateUserRequest
{
    Id = "E01B8491-3E60-408F-B06C-213CE8A05B8C",
    FirstName = "nima",
    LastName = "joodaki",
    BirthDate = Timestamp.FromDateTime(DateTime.Parse("1997-08-18").ToUniversalTime()),
    NationalCode = "1234562789"
});
Console.WriteLine("updated");

Console.WriteLine("=== DeleteUser ===");
await client.DeleteUserAsync(new DeleteUserRequest
{
    Id = createResponse.Id
});
Console.WriteLine("removed");

await channel.ShutdownAsync();

