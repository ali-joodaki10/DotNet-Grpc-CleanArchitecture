namespace Application.DTOs;

public record UserDto(
    string Id,
    string FirstName,
    string LastName,
    string NationalCode,
    DateTime BirthDate
);

