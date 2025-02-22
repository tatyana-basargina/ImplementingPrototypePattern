using ImplementingPrototypePattern;

namespace PrototypePatternTest;

public class UnitTestStudent
{
    public static Student GetTestStudent()
    {
        return new Student(new FullName("Иванов", "Иван", "Петрович"), 18, "Group-9");
    }

    [Fact]
    public void Student_Equal_Student_DeepCopy()
    {
        // Arrange
        Student student = GetTestStudent();
        Student studentDeepCopy = student.DeepCopy();

        // Act
        bool result = studentDeepCopy.Equals(student);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Student_Not_Equal_Student_DeepCopy_With_New_FullName()
    {
        // Arrange
        Student student = GetTestStudent();
        Student studentDeepCopy = student.DeepCopy();
        studentDeepCopy.FullName = new FullName();
        studentDeepCopy.GroupName = "Group-11";

        // Act
        bool result = studentDeepCopy.Equals(student);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void Student_Clone_Equal_Student_DeepCopy()
    {
        // Arrange
        Student student = GetTestStudent();
        Student studentDeepCopy = student.DeepCopy();
        Student studentClone = (Student)student.Clone();

        // Act
        bool result = studentDeepCopy.Equals(studentClone);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Student_ShallowCopy_Not_Equal_Student_DeepCopy_And_Equal_Student_With_New_Name()
    {
        // Arrange
        Student student = GetTestStudent();
        Student studentDeepCopy = student.DeepCopy();
        Student studentShallowCopy = student.ShallowCopy();
        student.FullName!.Name = "Петров";

        // Act
        bool result = !studentDeepCopy.Equals(studentShallowCopy) && student.Equals(studentShallowCopy);

        // Assert
        Assert.True(result);
    }
}