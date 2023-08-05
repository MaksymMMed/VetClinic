using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetClinic.DAL.Entities;

namespace VetClinic.BLL.DTO.Response
{
    public class AppointmentResponse
    {
        public string? Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsOver { get; set; }
        public string? DoctorId { get; set; }
        public string? AnimalId { get; set; }
        public DoctorResponse? Doctor { get; set; }
        public AnimalResponse? Animal { get; set; }
        public List<ProcedureResponse> Procedures { get; set; }
    }
}
