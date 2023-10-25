using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserEventSourcingPrototype.EventServices.Abstract;
using UserEventSourcingPrototype.EventServices.Concrete;
using UserEventSourcingPrototype.Features.Commands;
using UserEventSourcingPrototype.Features.Queries;

namespace UserEventSourcingPrototype.EventServices
{
    public class EventBroker
    {
        public List<IEvent> AllEvents = new();
        public event EventHandler<object> Commands;
        public event EventHandler<object> Queries;

        public EventBroker()
        {
            this.Commands += (sender, command) =>
            {
                if (command is ChangeAgePersonCommandRequest req1)
                {
                    ChangeAgePersonCommandHandler handler = new ChangeAgePersonCommandHandler();
                    var response = handler.ChangeAge(req1);
                    this.AllEvents.Add(new AgeChangedEvent(response.Person, response.OldAge, req1.Age));
                }
                else if (command is ChangeNamePersonCommandRequest req2)
                {
                    ChangeNamePersonCommandHandler handler = new ChangeNamePersonCommandHandler();
                    var response = handler.ChangeName(req2);
                    this.AllEvents.Add(new NameChangedEvent(response.Person, response.OldName, req2.Name));
                }
                else if (command is CreatePersonCommandRequest req3)
                {
                    CreatePersonCommandHandler handler = new CreatePersonCommandHandler();
                    CreatePersonCommandResponse response = handler.CreatePerson(req3);
                    this.AllEvents.Add(new PersonCreatedEvent(response.Person));
                }
            };
            this.Queries += (sender, query) =>
            {
                if (query is GetPersonQueryRequest req1)
                {
                    GetPersonQueryHandler handler = new GetPersonQueryHandler();
                    GetPersonQueryResponse response = handler.GetPerson(req1);
                    Console.WriteLine($"Id\tName\tAge");
                    Console.WriteLine(
                        $"{response.Person.Id}\t{response.Person.Name}\t{response.Person.Age}\n***********");
                }
                else if (query is GetAllPersonQueryRequest req2)
                {
                    GetAllPersonQueryHandler handler = new GetAllPersonQueryHandler();
                    List<GetAllPersonQueryResponse> response = handler.GetAll(req2);
                    Console.WriteLine($"Id\tName\tAge");
                    response.ForEach(person => Console.WriteLine($"{person.Id}\t{person.Name}\t{person.Age}"));
                    Console.WriteLine("***********");
                }
            };
        }

        //Client'ın 'Command' gönderebilmesi için kullanacağı metot.
        public void Command(object command)
            => Commands(this, command);
        //Client'ın 'Query' gönderebilmesi için kullanacağı metot.
        public void Query(object query)
            => Queries(this, query);
        //Tüm event'i yazdırabilmek/okuyabilmek için kullanılacak metot.
        public void WriteAllEvent()
            => AllEvents.ForEach(@event => Console.WriteLine($"{@event.ToString()}\n***********1231231"));
    }
}
