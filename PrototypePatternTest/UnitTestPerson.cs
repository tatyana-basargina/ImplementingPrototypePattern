using ImplementingPrototypePattern;

namespace PrototypePatternTest;

public class UnitTestPerson
{
    public static Person GetTestPerson()
    {
        Person person = new Person(new FullName() { LastName = "Иванов", Name = "Иван", Patronymic = "Иванович" }, 25);
        person.ProgrammingLanguages = new List<string>() {
            "C#", "TS", "SQL"
        };
        return person;
    }

    [Fact]
    public void Person_Equal_Person_DeepCopy()
    {
        // Arrange
        Person person = GetTestPerson();
        Person personDeepCopy = person.DeepCopy();

        // Act
        bool result = personDeepCopy.Equals(person);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Person_Not_Equal_Person_DeepCopy_With_New_FullName()
    {
        // Arrange
        Person person = GetTestPerson();
        Person personDeepCopy = person.DeepCopy();
        personDeepCopy.FullName = new FullName();

        // Act
        bool result = personDeepCopy.Equals(person);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void Person_Clone_Equal_Person_DeepCopy()
    {
        // Arrange
        Person person = GetTestPerson();
        Person personDeepCopy = person.DeepCopy();
        Person personClone = (Person)person.Clone();

        // Act
        bool result = personDeepCopy.Equals(personClone);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Person_ShallowCopy_Not_Equal_Person_DeepCopy_And_Equal_Person_With_New_Name()
    {
        // Arrange
        Person person = GetTestPerson();
        Person personDeepCopy = person.DeepCopy();
        Person personShallowCopy = person.ShallowCopy();
        person.FullName!.Name = "Петров";

        // Act
        bool result = !personDeepCopy.Equals(personShallowCopy) && person.Equals(personShallowCopy);

        // Assert
        Assert.True(result);
    }
}