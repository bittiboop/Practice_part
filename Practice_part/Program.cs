namespace Practice_part;

class Worker
{
    private string SurnameName;
    private string birthDate;
    private int contactNumber;
    private string email;
    private string position;
    private int description;
    private decimal salary; // Заробітна плата

    public decimal Salary
    {
        get => salary;
        set => salary = value;
    }

    public void SetSurnameName(string surnameName)
    {
        SurnameName = surnameName;
    }
    public string GetSurnameName()
    {
        return SurnameName;
    }
    public void SetBirthDate(string birthDate)
    {
        this.birthDate = birthDate;
    }
    public string GetBirthDate()
    {
        return birthDate;
    }
    public void SetContactNumber(int contactNumber)
    {
        this.contactNumber = contactNumber;
    }
    public int GetContactNumber()
    {
        return contactNumber;
    }
    public void SetEmail(string email)
    {
        this.email = email;
    }
    public string GetEmail()
    {
        return email;
    }
    public void SetPosition(string position)
    {
        this.position = position;
    }
    public string GetPosition()
    {
        return position;
    }
    public void SetDescription(int description)
    {
        this.description = description;
    }
    public int GetDescription()
    {
        return description;
    }

    // Перевантаження операторів
    public static Worker operator +(Worker worker, decimal amount)
    {
        worker.Salary += amount;
        return worker;
    }

    public static Worker operator -(Worker worker, decimal amount)
    {
        worker.Salary -= amount;
        return worker;
    }

    public static bool operator ==(Worker worker1, Worker worker2)
    {
        return worker1.Salary == worker2.Salary;
    }

    public static bool operator !=(Worker worker1, Worker worker2)
    {
        return worker1.Salary != worker2.Salary;
    }

    public static bool operator <(Worker worker1, Worker worker2)
    {
        return worker1.Salary < worker2.Salary;
    }

    public static bool operator >(Worker worker1, Worker worker2)
    {
        return worker1.Salary > worker2.Salary;
    }

    public override bool Equals(object obj)
    {
        if (obj is Worker otherWorker)
        {
            return this.Salary == otherWorker.Salary;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return Salary.GetHashCode();
    }
}
class Program
{
    static void Main(string[] args)
    {
        Worker worker = new Worker();
        Console.WriteLine("Enter surname and name:");
        worker.SetSurnameName(Console.ReadLine());
        Console.WriteLine("Enter birth date:");
        worker.SetBirthDate(Console.ReadLine());
        Console.WriteLine("Enter contact number:");
        worker.SetContactNumber(Convert.ToInt32(Console.ReadLine()));
        Console.WriteLine("Enter email:");
        worker.SetEmail(Console.ReadLine());
        Console.WriteLine("Enter position:");
        worker.SetPosition(Console.ReadLine());
        Console.WriteLine("Enter description:");
        worker.SetDescription(Convert.ToInt32(Console.ReadLine()));
        Console.WriteLine("Enter salary:");
        worker.Salary = Convert.ToDecimal(Console.ReadLine());
        
        Console.WriteLine($"Surname and Name: {worker.GetSurnameName()}");
        Console.WriteLine($"Birth Date: {worker.GetBirthDate()}");
        Console.WriteLine($"Contact Number: {worker.GetContactNumber()}");
        Console.WriteLine($"Email: {worker.GetEmail()}");
        Console.WriteLine($"Position: {worker.GetPosition()}");
        Console.WriteLine($"Description: {worker.GetDescription()}");
        Console.WriteLine($"Salary: {worker.Salary}");
    }
}