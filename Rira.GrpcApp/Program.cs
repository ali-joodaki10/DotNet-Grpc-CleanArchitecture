using Application.Commands;
using Application.Mappers;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Rira.GrpcApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<UserMapper>();
builder.Services.AddSingleton<UserMapperApp>();

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(CreateUserCommand).Assembly));

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddGrpcReflection();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<UserGrpcService>();
app.MapGrpcReflectionService();

app.MapGet("/", () => "gRPC service running");

app.Run();
