using System;
using System.Collections.Generic;

namespace home_task1_2
{
    

public class Passport
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string PassportNumber { get; set; }
    public DateTime DateOfIssue { get; set; }
    public DateTime DateOfExpiry { get; set; }

    public Passport(string lastName, string firstName, DateTime dateOfBirth, string passportNumber, DateTime dateOfIssue, DateTime dateOfExpiry)
    {
        LastName = lastName;
        FirstName = firstName;
        DateOfBirth = dateOfBirth;
        PassportNumber = passportNumber;
        DateOfIssue = dateOfIssue;
        DateOfExpiry = dateOfExpiry;
    }
    public override string ToString() => $"Surname: {LastName}, Name: {FirstName}, Date of birthday: {DateOfBirth.ToShortDateString()}, Number: {PassportNumber}, received: {DateOfIssue.ToShortDateString()}, valid until: {DateOfExpiry.ToShortDateString()}";
}

public class ForeignPassport : Passport
{
    public string ForeignPassportNumber { get; set; }
    public List<Visa> Visas { get; set; } = new List<Visa>();

    public ForeignPassport(string lastName, string firstName, DateTime dateOfBirth, string passportNumber, DateTime dateOfIssue, DateTime dateOfExpiry, string foreignPassportNumber) : base(lastName, firstName, dateOfBirth, passportNumber, dateOfIssue, dateOfExpiry)
    {
        ForeignPassportNumber = foreignPassportNumber;
    }

    public void AddVisa(Visa visa) => Visas.Add(visa);

    public override string ToString() => $"{base.ToString()}, Foreing №: {ForeignPassportNumber}, Visa: {string.Join(", ", Visas)}";
}

public class Visa
{
    public string Country { get; set; }
    public DateTime DateOfExpiry { get; set; }

    public Visa(string country, DateTime dateOfExpiry)
    {
        Country = country;
        DateOfExpiry = dateOfExpiry;
    }

    public override string ToString() => $"{Country} to {DateOfExpiry.ToShortDateString()}";
}

public class Example
{
    public static void Main(string[] args)
    {
        var foreing_passport = new ForeignPassport("Sergiy", "Kostirov", new DateTime(2002, 5, 13), "56783", new DateTime(2024, 12, 17), new DateTime(2027, 12, 17), "67543");
        foreing_passport.AddVisa(new Visa("USA", new DateTime(2027, 12, 31)));
        Console.WriteLine(foreing_passport);
    }
}

}