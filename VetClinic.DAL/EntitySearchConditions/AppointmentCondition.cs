using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetClinic.DAL.EntitySearchConditions
{
    public class AppointmentCondition
    {
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public bool? IsOver { get; set; }
    }
}
