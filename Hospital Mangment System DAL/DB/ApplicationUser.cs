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
        public string role_Type { get; set; } //(Doctor,nurse,patient)
    }
}
