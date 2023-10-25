using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserEventSourcingPrototype.Entities;

namespace UserEventSourcingPrototype.Features.Queries
{
    public class GetPersonQueryRequest
    {
        public int Id { get; set; }
    }
    class GetPersonQueryResponse
    {
        public Person Person;
    }
    class GetPersonQueryHandler
    {
        public GetPersonQueryResponse GetPerson(GetPersonQueryRequest request)
        {
            Person person = PersonSource.PersonList.FirstOrDefault(p => p.Id == request.Id);
            return new GetPersonQueryResponse
            {
                Person = person
            };
        }
    }
}
