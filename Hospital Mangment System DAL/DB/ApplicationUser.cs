using Hospital_Mangment_System_DAL.Entites;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Mangment_System_DAL.DB
{
    public  class ApplicationUser:IdentityUser
    {

        public string Role_Type { get; set; } //(Doctor,nurse,patient)
        public string Phone { get; set; }
        // relations 
        public virtual Nurse Nurse { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
