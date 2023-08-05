using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetClinic.DAL.EntitySearchConditions
{
    public class AnimalCondition
    {
        public string? AnimalName { get; set; }
        public int? MaxAnimalAge { get; set;}
        public int? MinAnimalAge { get; set;}
        public int? AnimalSex { get; set;}
        public int[]? AnimalKinds { get; set;}
    }
}
