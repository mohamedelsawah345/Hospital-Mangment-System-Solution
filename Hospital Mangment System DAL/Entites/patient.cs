using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Mangment_System_DAL.Entites
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public bool? IsDeleted { get; set; }

        public DateOnly birthday { get; set; }


        public string phone1 { get; set; }

        public string? phone2 { get; set; }

        public char Gender { get; set; }
        public string ?Imagepath { get; set; }
        public List<Bill>? Bills { get; set; }
        public List<Appointment>? Appointments { get; set; }
        public List<Addmission>? Addmissions { get; set; }
        public List<Lap_test>? lap_Tests { get; set; }

    }
}
