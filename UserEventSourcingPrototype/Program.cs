using UserEventSourcingPrototype.EventServices;
using UserEventSourcingPrototype.Features.Commands;
using UserEventSourcingPrototype.Features.Queries;

namespace UserEventSourcingPrototype
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EventBroker eventBroker = new EventBroker();
            eventBroker.Command(new CreatePersonCommandRequest() { Id = 10, Age = 23, Name = "Aslı" });
            eventBroker.Command(new CreatePersonCommandRequest() { Id = 11, Age = 33, Name = "Mehmet" });
            eventBroker.Command(new ChangeNamePersonCommandRequest() { Id = 10, Name = "Aslıhan" });
            eventBroker.Command(new ChangeAgePersonCommandRequest() { Id = 11, Age = 13 });
            eventBroker.WriteAllEvent();
            eventBroker.Query(new GetAllPersonQueryRequest());
            eventBroker.Query(new GetPersonQueryRequest() { Id = 3 });
        }
    }
}