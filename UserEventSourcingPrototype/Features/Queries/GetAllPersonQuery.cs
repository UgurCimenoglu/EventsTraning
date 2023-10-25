using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserEventSourcingPrototype.Entities;

namespace UserEventSourcingPrototype.Features.Queries
{
    public class GetAllPersonQueryRequest
    {
    }
    class GetAllPersonQueryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
    class GetAllPersonQueryHandler
    {
        public List<GetAllPersonQueryResponse> GetAll(GetAllPersonQueryRequest request)
        {
            return PersonSource.PersonList.Select(person => new GetAllPersonQueryResponse
            {
                Id = person.Id,
                Age = person.Age,
                Name = person.Name
            }).ToList();
        }
    }
}
