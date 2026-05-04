namespace Application.DTOs;

public record UpdateUserDto(
    string Id,
    string FirstName,
    string LastName,
    string NationalCode,
    DateTime BirthDate
);