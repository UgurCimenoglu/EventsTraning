using UserEventSourcingPrototype.Entities;
using UserEventSourcingPrototype.EventServices.Abstract;

namespace UserEventSourcingPrototype.EventServices.Concrete;

public class PersonCreatedEvent : IEvent
{
    public Person Person { get; set; }

    public PersonCreatedEvent(Person person)
    {
        Person = person;
    }

    public override string ToString()
        => $"Yeni personel {Person.Id} id değerinde eklenmiştir.";
}