﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetClinic.DAL.Entities
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsOver { get; set; }
        public int? DoctorId { get; set; }
        public int? AnimalId { get; set; }
        public Doctor? Doctor { get; set; }
        public Animal? Animal { get; set; }
        public List<Procedure> Procedures { get; set; }
    }
}
