namespace Practice_part;

class City
{
    private string name;
    private string country;
    private int population;
    private int phoneCode;
    private string nameArea;

    public int Population
    {
        get => population;
        set => population = value;
    }

    public void SetName(string name)
    {
        this.name = name;
    }
    public string GetName()
    {
        return name;
    }
    public void SetCountry(string country)
    {
        this.country = country;
    }
    public string GetCountry()
    {
        return country;
    }
    public void SetPhoneCode(int phoneCode)
    {
        this.phoneCode = phoneCode;
    }
    public int GetPhoneCode()
    {
        return phoneCode;
    }
    public void SetNameArea(string nameArea)
    {
        this.nameArea = nameArea;
    }
    public string GetNameArea()
    {
        return nameArea;
    }

    public static City operator +(City city, int amount)
    {
        city.Population += amount;
        return city;
    }

    public static City operator -(City city, int amount)
    {
        city.Population -= amount;
        return city;
    }

    public static bool operator ==(City city1, City city2)
    {
        return city1.Population == city2.Population;
    }

    public static bool operator !=(City city1, City city2)
    {
        return city1.Population != city2.Population;
    }

    public static bool operator <(City city1, City city2)
    {
        return city1.Population < city2.Population;
    }

    public static bool operator >(City city1, City city2)
    {
        return city1.Population > city2.Population;
    }

    public override bool Equals(object obj)
    {
        if (obj is City otherCity)
        {
            return this.Population == otherCity.Population;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return Population.GetHashCode();
    }
}

class Program
{
    static void Main(string[] args)
    {
        City city1 = new City();
        city1.SetName("New York");
        city1.SetCountry("USA");
        city1.SetPhoneCode(212);
        city1.SetNameArea("Manhattan");
        city1.Population = 8000000;

        City city2 = new City();
        city2.SetName("Los Angeles");
        city2.SetCountry("USA");
        city2.SetPhoneCode(213);
        city2.SetNameArea("Downtown");
        city2.Population = 4000000;

        Console.WriteLine($"{city1.GetName()} in {city1.GetCountry()} has a population of {city1.Population}");
        Console.WriteLine($"{city2.GetName()} in {city2.GetCountry()} has a population of {city2.Population}");

        if (city1 > city2)
            Console.WriteLine($"{city1.GetName()} has a larger population than {city2.GetName()}");
        else
            Console.WriteLine($"{city2.GetName()} has a larger population than {city1.GetName()}");

        city1 += 100000; 
        Console.WriteLine($"After increase, {city1.GetName()} has a population of {city1.Population}");
    }
}