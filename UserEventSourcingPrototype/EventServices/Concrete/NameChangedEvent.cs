﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserEventSourcingPrototype.Entities;
using UserEventSourcingPrototype.EventServices.Abstract;

namespace UserEventSourcingPrototype.EventServices.Concrete
{
    public class NameChangedEvent : IEvent
    {
        public Person Person { get; set; }
        public string oldName, newName;
        public NameChangedEvent(Person person, string oldName, string newName)
        {
            Person = person;
            this.oldName = oldName;
            this.newName = newName;
        }
        public override string ToString()
            => $"Id değeri {Person.Id} olan personelin adı değiştirilmiştir.\nEski adı : {oldName}\nYeni adı : {newName}";
    }
}
