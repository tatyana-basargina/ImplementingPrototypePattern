namespace ImplementingPrototypePattern;

public class Employee : Person, IEquatable<Employee>
{
    public string? Position { get; set; }
    public Employee() { }
    public Employee(FullName fullName, int age, string position)
        : base(fullName, age)
    {
        Position = position;
    }
    public Employee(Employee employee)
        : base(employee)
    {
        Position = employee.Position;
    }

    public override Employee ShallowCopy()
    {
        return (Employee)MemberwiseClone();
    }

    public override Employee DeepCopy()
    {
        return new Employee(this);
    }
    public new object Clone()
    {
        return DeepCopy();
    }
    public override bool Equals(object obj)
    {
        return Equals(obj as Employee);
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), Position);
    }
    public bool Equals(Employee? other)
    {
        bool result = base.Equals(other);

        if (other?.Position == null)
        {
            return result;
        }

        result &= Position == other.Position;

        return result;
    }
}