using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetClinic.DAL.Entities;

namespace VetClinic.BLL.DTO.Response
{
    public class ProcedureResponse
    {
        public string? Id { get; set; }
        public string AppointmentId { get; set; }
        //public Appointment Appointment { get; set; }
        public int Price { get; set; }
        public string ProcedureName { get; set; }
    }
}
