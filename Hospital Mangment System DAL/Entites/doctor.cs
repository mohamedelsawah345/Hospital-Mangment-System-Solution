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
    public class Doctor 
    {
        [Key]
        public string ApplicationUserId { get; set; } // Foreign key for ApplicationUser
        public virtual ApplicationUser ApplicationUser { get; set; }
        public string Phone { get; set; }
        public string Speciality { get; set; }
        public bool IsDeleted { get; set; } = false;
        // Navigation property - A doctor works in one department
        public int Dnum { get; set; }
        public virtual Department department { get; set; }

        // Navigation property - A doctor may manage one department
        public List<Lap_test> lap_Tests { get; set; }
        public virtual Department ManagedDepartment { get; set; }
        
    }
}
