using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetClinic.DAL.Entities
{
    public class Animal
    {
        public string Id { get; set; }
        public string Name { get;set; }
        public int Age { get;set; }
        public string Description { get; set; }
        public Sex AnimalSex { get;set; }
        public Kind AnimalKind { get;set; }
        public string OwnerId { get;set; }
        public Customer Owner { get;set; }
        public List<Appointment>? Appointments { get; set; }

        public enum Sex
        {
              Male,
              Female
        }

        public enum Kind
        {
            Dog,
            Cat,
            Mouse,
            Bunny,
            Parrot,
            Hamster,
            Turtle,
            Lizard,
            Other
        }
    }
}
