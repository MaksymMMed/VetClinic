using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetClinic.DAL.Entities
{
    public class Reception:BaseEntity
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsOver { get; set; }
        public int DoctorId { get; set; }
        public int AnimalId { get; set; }
        public Doctor Doctor { get; set; }
        public Animal Animal { get; set; }
        public List<ProcedureType> Procedures { get; set; }


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
