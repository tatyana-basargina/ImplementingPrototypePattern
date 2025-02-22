using ImplementingPrototypePattern;

namespace PrototypePatternTest
{
    public class UnitTestEmployee
    {
        public static Employee GetTestEmployee()
        {
            return new Employee(new FullName("Иванов", "Иван", "Иванович"), 45, "Преподаватель");
        }

        [Fact]
        public void Employee_Equal_Employee_DeepCopy()
        {
            // Arrange
            Employee employee = GetTestEmployee();
            Employee employeeDeepCopy = employee.DeepCopy();

            // Act
            bool result = employeeDeepCopy.Equals(employee);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Employee_Not_Equal_Employee_DeepCopy_With_New_FullName()
        {
            // Arrange
            Employee employee = GetTestEmployee();
            Employee employeeDeepCopy = employee.DeepCopy();
            employeeDeepCopy.FullName = new FullName();
            employeeDeepCopy.Position = "Директор";

            // Act
            bool result = employeeDeepCopy.Equals(employee);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Employee_Clone_Equal_Employee_DeepCopy()
        {
            // Arrange
            Employee employee = GetTestEmployee();
            Employee employeeDeepCopy = employee.DeepCopy();
            Employee employeeClone = (Employee)employee.Clone();

            // Act
            bool result = employeeDeepCopy.Equals(employeeClone);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Employee_ShallowCopy_Not_Equal_Employee_DeepCopy_And_Equal_Employee_With_New_Name()
        {
            // Arrange
            Employee employee = GetTestEmployee();
            Employee employeeDeepCopy = employee.DeepCopy();
            Employee employeeShallowCopy = employee.ShallowCopy();
            employee.FullName!.Name = "Петров";

            // Act
            bool result = !employeeDeepCopy.Equals(employeeShallowCopy) && employee.Equals(employeeShallowCopy);

            // Assert
            Assert.True(result);
        }
    }
}