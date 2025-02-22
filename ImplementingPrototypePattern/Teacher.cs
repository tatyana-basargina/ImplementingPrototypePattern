namespace ImplementingPrototypePattern;

public class Teacher : Employee, ICloneable, IEquatable<Teacher>
{
    public List<Student>? Students { get; set; }
    public Teacher() { }
    public Teacher(FullName fullName, int age, string position)
        : base(fullName, age, position)
    { 
    }
    public Teacher(Teacher teacher)
        : base(teacher)
    {
        if (teacher.Students != null)
        {
            Students = new List<Student>(teacher.Students);
        }
    }

    public override Teacher ShallowCopy()
    {
        return (Teacher)MemberwiseClone();
    }

    public override Teacher DeepCopy()
    {
        return new Teacher(this);
    }

    public new object Clone()
    {
        return DeepCopy();
    }
    public override bool Equals(object obj)
    {
        return Equals(obj as Teacher);
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), Students);
    }
    public bool Equals(Teacher? other)
    {
        bool result = base.Equals(other);

        if (other?.Students == null)
        {
            return result;
        }
        if (other?.Students != null && Students != null)
        {
            result &= Students.SequenceEqual(other.Students);
        }

        return result;
    }
}
