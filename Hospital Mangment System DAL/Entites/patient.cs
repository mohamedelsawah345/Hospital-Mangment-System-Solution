using Hospital_Mangment_System_DAL.DB;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Mangment_System_DAL.Entites
{
    public class Patient
    {
       
        public string ApplicationUserId { get; set; } // Foreign key for ApplicationUser
        public virtual ApplicationUser ApplicationUser { get; set; }

        public string Phone { get; set; }
        public bool? IsDeleted { get; set; }
        public DateOnly birthday { get; set; }
        public char Gender { get; set; }
        public string ?Imagepath { get; set; }
        public List<Bill>? Bills { get; set; }
        public List<Appointment>? Appointments { get; set; }
        public List<Addmission>? Addmissions { get; set; }
        public List<Lap_test>? lap_Tests { get; set; }
    }
}
