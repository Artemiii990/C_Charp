using System;
using System.Collections.Generic;



public class Human
{
    public string name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Address { get; set; }

    public Human(string Name, DateTime dateOfBirth, string address)
    {
        name = Name;
        DateOfBirth = dateOfBirth;
        Address = address;
    }

    public virtual string GetInfo()
    {
        return $"Name: {name}, Date of birthday: {DateOfBirth.ToShortDateString()}, Address: {Address}";
    }
}

public class Builder : Human
{
    public string Specialization { get; set; }
    public int ExperienceYears { get; set; }

    public Builder(string name, DateTime dateOfBirth, string address, string specialization, int experienceYears) : base(name, dateOfBirth, address)
    {
        Specialization = specialization;
        ExperienceYears = experienceYears;
    }

    public override string GetInfo()
    {
        return $"{base.GetInfo()}, Спеціалізація: {Specialization}, Досвід роботи: {ExperienceYears} років";
    }

    public string BuildHouse()
    {
        return $"Будівельник {name} будує будинок.";
    }
}

public class Sailor : Human
{
    public string ShipName { get; set; }
    public string Rank { get; set; }

    public Sailor(string name, DateTime dateOfBirth, string address, string shipName, string rank) : base(name, dateOfBirth, address)
    {
        ShipName = shipName;
        Rank = rank;
    }

    public override string GetInfo()
    {
        return $"{base.GetInfo()}, Назва корабля: {ShipName}, Звання: {Rank}";
    }

    public string SailShip()
    {
        return $"Моряк {name} керує кораблем {ShipName}.";
    }
}

public class Pilot : Human
{
    public string AircraftType { get; set; }
    public int FlightHours { get; set; }

    public Pilot(string name, DateTime dateOfBirth, string address, string aircraftType, int flightHours) : base(name, dateOfBirth, address)
    {
        AircraftType = aircraftType;
        FlightHours = flightHours;
    }

    public override string GetInfo()
    {
        return $"{base.GetInfo()}, Тип літака: {AircraftType}, Наліт: {FlightHours} годин";
    }

    public string FlyPlane()
    {
        return $"Пілот {name} пілотує {AircraftType}.";
    }
}

public class Result
{
    public static void Main(string[] args)
    {
        var builder = new Builder("Іван", new DateTime(1985, 5, 10), "вул. Динамська, 32", "Зварювальник", 15);
        Console.WriteLine(builder.GetInfo());
        Console.WriteLine(builder.BuildHouse());

        var sailor = new Sailor("Марія", new DateTime(1992, 11, 2), "вул. Морська, 7", "Шторм", "Капітан");
        Console.WriteLine(sailor.GetInfo());
        Console.WriteLine(sailor.SailShip());

        var pilot = new Pilot("Олексій", new DateTime(1978, 8, 20), "вул. Жадібна, 8", "Боїнг 737", 10000);
        Console.WriteLine(pilot.GetInfo());
        Console.WriteLine(pilot.FlyPlane());
    }
}
