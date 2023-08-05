using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetClinic.BLL.DTO.Response;
using VetClinic.DAL.Entities;

namespace VetClinic.BLL.DTO.Request
{
    public class AppointmentRequest
    {
        public string? Id { get; set; }
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
        public bool IsOver { get; set; }
        public string? DoctorId { get; set; }
        public string? AnimalId { get; set; }
        public List<ProcedureResponse>? Procedures { get; set; }
    }
}
