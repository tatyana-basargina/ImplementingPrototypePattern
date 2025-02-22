using ImplementingPrototypePattern;

Person person1 = new Person(
    new FullName()
    {
        LastName = "Иванов",
        Name = "Иван",
        Patronymic = "Иванович"
    }, 25);
person1.ProgrammingLanguages = new List<string>() { "C#", "TS", "SQL" };

// Выполнить поверхностное копирование person1 и присвоить её person2.
Person person2 = person1.ShallowCopy();
// Сделать глубокую копию person1 и присвоить её person3.
Person person3 = person1.DeepCopy();

// Вывести значения person1, person2 и person3.
Console.WriteLine("Original values of person1, person2, person3:");
Console.WriteLine("   person1 instance values: ");
person1.DisplayValues();
Console.WriteLine("   person2 instance values:");
person2.DisplayValues();
Console.WriteLine("   person3 instance values:");
person3.DisplayValues();

// Изменить значение свойств person1 и отобразить значения person1, person2 и person3.
person1.Age = 32;
person1.FullName!.Name = "Frank";
person1.ProgrammingLanguages.Add("C");
Console.WriteLine("\nValues of person1, person2 and person3 after changes to person1:");
Console.WriteLine("   person1 instance values: ");
person1.DisplayValues();
Console.WriteLine("   person2 instance values (reference values have changed):");
person2.DisplayValues();
Console.WriteLine("   person3 instance values (everything was kept the same):");
person3.DisplayValues();