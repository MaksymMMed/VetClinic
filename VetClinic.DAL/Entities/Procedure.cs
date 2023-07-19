using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetClinic.DAL.Entities
{
    public class Procedure
    {
        public string Id { get; set; }
        public string AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
        public int Price { get; set; }
        public ProcedureType ProcedureName { get; set; }
        public enum ProcedureType
        {
            PhysicalExamination,
            Vaccination,
            WoundDisinfection,
            Spaying,
            DenthalCheck,
            LabTests,
            Radiology,
            Ultrasonography,
            Electocardiodiagram,
            SurgicalProcedures
        }
    }
}
