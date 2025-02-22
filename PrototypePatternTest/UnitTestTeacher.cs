using ImplementingPrototypePattern;

namespace PrototypePatternTest
{
    public class UnitTestTeacher
    {
        public static Teacher GetTestTeacher()
        {
            Teacher teacher = new Teacher(new FullName("Иванов", "Иван", "Иванович"), 45, "Преподаватель");
            teacher.ProgrammingLanguages = new List<string>() { "C#" };
            teacher.Students = new List<Student>()
            {
                UnitTestStudent.GetTestStudent()
            };
            return teacher;
        }

        [Fact]
        public void Teacher_Equal_Teacher_DeepCopy()
        {
            // Arrange
            Teacher Teacher = GetTestTeacher();
            Teacher TeacherDeepCopy = Teacher.DeepCopy();

            // Act
            bool result = TeacherDeepCopy.Equals(Teacher);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Teacher_Not_Equal_Teacher_DeepCopy_With_New_FullName()
        {
            // Arrange
            Teacher Teacher = GetTestTeacher();
            Teacher TeacherDeepCopy = Teacher.DeepCopy();
            TeacherDeepCopy.FullName = new FullName();

            // Act
            bool result = TeacherDeepCopy.Equals(Teacher);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Teacher_Clone_Equal_Teacher_DeepCopy()
        {
            // Arrange
            Teacher Teacher = GetTestTeacher();
            Teacher TeacherDeepCopy = Teacher.DeepCopy();
            Teacher TeacherClone = (Teacher)Teacher.Clone();

            // Act
            bool result = TeacherDeepCopy.Equals(TeacherClone);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Teacher_ShallowCopy_Not_Equal_Teacher_DeepCopy_And_Equal_Teacher_With_New_Name()
        {
            // Arrange
            Teacher Teacher = GetTestTeacher();
            Teacher TeacherDeepCopy = Teacher.DeepCopy();
            Teacher TeacherShallowCopy = Teacher.ShallowCopy();
            Teacher.FullName!.Name = "Петров";

            // Act
            bool result = !TeacherDeepCopy.Equals(TeacherShallowCopy) && Teacher.Equals(TeacherShallowCopy);

            // Assert
            Assert.True(result);
        }
    }
}