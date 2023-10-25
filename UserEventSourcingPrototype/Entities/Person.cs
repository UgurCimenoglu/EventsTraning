using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserEventSourcingPrototype.Entities
{
    public record Person
    {
        public int Id { get; init; }
        public string Name { get; private set; }
        public int Age { get; private set; }

        public Person(int id, string name, int age)
        {
            (Id, Name, Age) = (id, name, age);
        }

        public void ChangeName(string name) => Name = name;
        public void ChangeAge(int age) => Age = age;

    }
    class PersonSource
    {
        public static List<Person> PersonList = new()
        {
            new(1, "Ali", 28),
            new(2, "Veli", 30),
            new(3, "Coşgun", 42),
            new(4, "Ahmet", 32)
        };
    }
}
