using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Mangment_System_DAL.Entites
{
    public class Appointment
    {
        [Key]
        public int Appointment_Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime timeOftheappointment { get; set; }
        public string Reason_Of_Visit { get; set; }
        public int patient_id { get; set; }
        public Patient patient { get; set; }

    }
}
