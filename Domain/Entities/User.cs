using System;
using System.Numerics;

namespace Domain.Entities;

public class User
{
    public Guid Id { get; private set; }
    public string FirstName { get; private set; } = default!;
    public string LastName { get; private set; } = default!;
    public string NationalCode { get; private set; } = default!;
    public DateTime BirthDate { get; private set; } = default!;

    private User() { }

    public User(string firstName, string lastName, string nationalCode, DateTime birthDate)
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        NationalCode = nationalCode;
        BirthDate = birthDate;
    }

    public void Update(string firstName, string lastName, string nationalCode, DateTime birthDate)      
    {
        FirstName = firstName;
        LastName = lastName;
        NationalCode = nationalCode;
        BirthDate = birthDate;
    }
}
