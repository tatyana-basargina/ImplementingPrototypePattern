namespace ImplementingPrototypePattern;

public class Student : Person, IEquatable<Student>
{
    public string? GroupName { get; set; }
    public Student() { }
    public Student(FullName fullName, int age, string? groupName)
        : base(fullName, age)
    {
        GroupName = groupName;
    }
    public Student(Student student)
        : base(student)
    {
        GroupName = student.GroupName;
    }
    public override Student ShallowCopy()
    {
        return (Student)MemberwiseClone();
    }
    public override Student DeepCopy()
    {
        return new Student(this);
    }
    public new object Clone()
    {
        return DeepCopy();
    }
    public override bool Equals(object obj)
    {
        return Equals(obj as Student);
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), GroupName);
    }
    public bool Equals(Student? other)
    {
        bool result = base.Equals(other);

        if (other?.GroupName == null)
        {
            return result;
        }

        result &= GroupName == other.GroupName;

        return result;
    }
}
