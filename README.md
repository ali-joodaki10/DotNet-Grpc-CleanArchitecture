# DotNet-Grpc-CleanArchitecture
A .NET gRPC sample project built with Clean Architecture, MediatR, and EF Core. Includes a console-based gRPC client for testing CRUD operations.
MediatR • EF Core • SQL • gRPC • Clean Architecture
This repository contains a sample application demonstrating how to build a gRPC-based service using Clean Architecture, MediatR, and Entity Framework Core.

A console-based gRPC client is also included for testing CRUD operations.

Overview
This project showcases how to:

Structure a .NET application using Clean Architecture
Implement gRPC instead of REST for communication
Use the Mediator pattern (MediatR) for decoupled request handling
Integrate SQL database using EF Core
Test gRPC endpoints via a console client
Architecture
The solution is organized into clean, independent layers:

Domain – Core entities, business rules, and domain models
Application – Commands, queries, and Mediator handlers
Infrastructure – EF Core, SQL database access, repositories, external services
GrpcServices – gRPC service definitions and protobuf message handlers
Rira.GrpcApp – Main gRPC host application
Rira.ConsoleApp – Console-based gRPC client for testing
This separation ensures high maintainability, scalability, and testability.

Technologies Used
.NET
gRPC
Protocol Buffers (protobuf)
MediatR
SQL Database
Entity Framework Core
Clean Architecture
gRPC Communication
The application exposes gRPC endpoints instead of REST controllers.

Communication is handled through Protocol Buffers, enabling:

Strongly-typed contracts
High performance
Lightweight message serialization
Testing the gRPC Services
The included Rira.ConsoleApp project acts as a gRPC client and can:

Send requests to the server
Test CRUD operations
Validate service behavior
Just run the console project and observe responses to verify the server functionality.

Project Structure
text
RiraTask
│
├── Domain
├── Application
├── Infrastructure
├── GrpcServices
├── Rira.GrpcApp
└── Rira.ConsoleApp
Purpose
This project aims to provide a clear, maintainable reference for:

Building gRPC services in .NET
Applying Clean Architecture principles
Using MediatR to organize business logic
Working with SQL databases
Testing gRPC endpoints using console clients
