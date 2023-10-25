using UserEventSourcingPrototype.Entities;

namespace UserEventSourcingPrototype.Features.Commands;

public class CreatePersonCommandRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}
public class CreatePersonCommandResponse
{
    public Person Person { get; set; }
}
public class CreatePersonCommandHandler
{
    public CreatePersonCommandResponse CreatePerson(CreatePersonCommandRequest request)
    {
        PersonSource.PersonList.Add(new Person(request.Id, request.Name, request.Age));
        return new CreatePersonCommandResponse
        {
            Person = PersonSource.PersonList.Last()
        };
    }
}