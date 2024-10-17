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
       
        public string ApplicationUserId { get; set; } // Foreign key for ApplicationUser
        public virtual ApplicationUser ApplicationUser { get; set; }
        public string Phone { get; set; }
        public bool IsDeleted { get; set; }
        public int Dnum { get; set; }
        public string Imagepath { get; set; }
        public Department? Department { get; set; }
      
    }
}
