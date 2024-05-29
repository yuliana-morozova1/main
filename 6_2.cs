using System;

public abstract class Profession
{
    public string ProfessionName { get; set; }
    public string Industry { get; set; }

    public Profession()
    {
        ProfessionName = "";
        Industry = "";
    }

    public Profession(string professionName, string industry)
    {
        ProfessionName = professionName;
        Industry = industry;
    }

    public abstract string doJob();

    public override string ToString()
    {
        return "Profession Info:\nProfession Name: " + ProfessionName + "\nIndustry: " + Industry + "\n";
    }
}

class Pilot : Profession
{
    public string AircraftType { get; set; }

    public Pilot(string professionName, string industry, string type) : base(professionName, industry)
    {
        AircraftType = type;
    }

    public override string doJob()
    {
        return $"Pilot controls {AircraftType}";
    }

    public override bool Equals(object obj)
    {
        if (obj is Pilot)
        {
            return ToString().Equals(((Pilot)obj).ToString());
        }
        return false;
    }

    public override int GetHashCode()
    {
        return ToString().GetHashCode();
    }

    public override string ToString()
    {
        return "Pilot Info\n" + base.ToString() + "\nAircraft type: " + AircraftType;
    }
}

class Developer : Profession
{
    public string Skills { get; set; }

    public Developer(string professionName, string industry, string skills)
        : base(professionName, industry)
    {
        Skills = skills;
    }

    public override string doJob()
    {
        return $"Developer writes code:\n{Skills}";
    }

    public override bool Equals(object obj)
    {
        if (obj is Developer)
        {
            return ToString().Equals(((Developer)obj).ToString());
        }
        return false;
    }

    public override int GetHashCode()
    {
        return ToString().GetHashCode();
    }

    public override string ToString()
    {
        return "Developer Info\n" + base.ToString() + "\nSkills: " + Skills;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Pilot pilot = new Pilot("Pilot", "Aviation", "Boeing 747");
        Developer developer = new Developer("Developer", "Software Development", "C#, Java, Python");

        Console.WriteLine(pilot.doJob());
        Console.WriteLine(developer.doJob());
    }
}
