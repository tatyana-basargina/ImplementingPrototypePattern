namespace ImplementingPrototypePattern;

public class Person : IMyCloneable<Person>, ICloneable, IEquatable<Person>
{
    public FullName? FullName { get; set; }
    public int Age { get; set; }
    public List<string>? ProgrammingLanguages { get; set; }

    public Person() { }
    public Person(FullName fullName)
    {
        FullName = fullName;
    }
    public Person(FullName fullName, int age)
        : this(fullName)
    {
        Age = age;
    }
    protected Person(Person person)
    {
        if (person.FullName != null)
        {
            FullName = new FullName(person.FullName);
        }
        Age = person.Age;
        if (person.ProgrammingLanguages != null)
        {
            ProgrammingLanguages = new List<string>(person.ProgrammingLanguages);
        }
    }

    public virtual Person ShallowCopy()
    {
        return (Person)MemberwiseClone();
    }

    public virtual Person DeepCopy()
    {
        return new Person(this);
    }

    public object Clone()
    {
        return DeepCopy();
    }

    public override bool Equals(object obj)
    {
        return Equals(obj as Person);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(FullName, Age, ProgrammingLanguages);
    }

    public bool Equals(Person? other)
    {
        if (other is null)
        {
            return false;
        }

        bool result = FullName?.Name == other.FullName?.Name
                && FullName?.LastName == other.FullName?.LastName
                && FullName?.Patronymic == other.FullName?.Patronymic
                && Age == other.Age;

        if (ProgrammingLanguages != null && other.ProgrammingLanguages != null)
        {
            result &= ProgrammingLanguages.SequenceEqual(other.ProgrammingLanguages);
        }

        return result;
    }
    public void DisplayValues()
    {
        Console.WriteLine($"      FullName: {FullName}, Age: {Age}");
        if (ProgrammingLanguages != null)
        {
            Console.Write("      ProgrammingLanguages: ");
            foreach (var p in ProgrammingLanguages)
            {
                Console.Write($"{p} ");
            }
        }
        Console.WriteLine();
    }
}
