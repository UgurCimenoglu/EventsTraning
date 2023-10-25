using UserEventSourcingPrototype.Entities;

namespace UserEventSourcingPrototype.Features.Commands;

public class ChangeAgePersonCommandRequest
{
    public int Id { get; set; }
    public int Age { get; set; }
}
public class ChangeAgePersonCommandResponse
{
    public Person Person { get; set; }
    public int OldAge { get; set; }
}
public class ChangeAgePersonCommandHandler
{
    public ChangeAgePersonCommandResponse ChangeAge(ChangeAgePersonCommandRequest request)
    {
        Person person = PersonSource.PersonList.FirstOrDefault(p => p.Id == request.Id);
        int oldAge = person.Age;
        person.ChangeAge(request.Age);
        return new ChangeAgePersonCommandResponse
        {
            Person = person,
            OldAge = oldAge
        };
    }
}