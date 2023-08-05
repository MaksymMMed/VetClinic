using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetClinic.DAL.Entities;

namespace VetClinic.BLL.DTO.Response
{
    public class AnimalResponse
    {
        public string? Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Description { get; set; }
        public string AnimalSex { get; set; }
        public string AnimalKind { get; set; }
        public string OwnerId { get; set; }
        public CustomerResponse Owner { get; set; }
        public List<AppointmentResponse>? Appointments { get; set; }
    }
}
