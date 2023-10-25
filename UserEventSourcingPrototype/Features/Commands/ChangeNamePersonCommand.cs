using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserEventSourcingPrototype.Entities;

namespace UserEventSourcingPrototype.Features.Commands
{
    public class ChangeNamePersonCommandRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class ChangeNamePersonCommandResponse
    {
        public Person Person { get; set; }
        public string OldName { get; set; }
    }
    public class ChangeNamePersonCommandHandler
    {
        public ChangeNamePersonCommandResponse ChangeName(ChangeNamePersonCommandRequest request)
        {
            Person person = PersonSource.PersonList.FirstOrDefault(p => p.Id == request.Id);
            var oldName = person.Name;
            person.ChangeName(request.Name);
            return new ChangeNamePersonCommandResponse
            {
                Person = person,
                OldName = oldName
            };
        }
    }
}
