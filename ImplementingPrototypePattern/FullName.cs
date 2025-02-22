namespace ImplementingPrototypePattern;

public class FullName
{
    public string Name { get; set; } = null!;
    public string? LastName { get; set; }
    public string? Patronymic { get; set; }

    public FullName() { }
    public FullName(string name) 
    {
        Name = name;
    }
    public FullName(string name, string? lastName)
        : this(name)
    { 
        LastName = lastName;
    }
    public FullName(string name, string? lastName, string? patronymic)
        : this(name, lastName)
    {
        Patronymic = patronymic;
    }
    public FullName(FullName fullName) 
    {
        Name = fullName.Name;
        LastName = fullName.LastName;
        Patronymic = fullName.Patronymic;
    }

    public override string ToString()
    {
        return $"{LastName} {Name} {Patronymic}";
    }
}
