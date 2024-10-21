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
    public class Nurse
    {
        [Key]
        public string ApplicationUserId { get; set; } // Foreign key for ApplicationUser
        public string Phone { get; set; }
        public bool IsDeleted { get; set; } = false;
        public int Dnum { get; set; }
        public Department? Department { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
