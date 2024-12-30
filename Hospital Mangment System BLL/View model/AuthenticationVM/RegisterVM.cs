using Hospital_Mangment_System_BLL.View_model.DepartmentVM;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Mangment_System_BLL.View_model.AuthenticationVM
{
    public class RegisterVM
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string? Speciality { get; set; } // For Doctor
        public int? DepartmentId { get; set; } // For Doctor and Nurse
        public DateOnly? Birthday { get; set; } // For Patient
        public char Gender { get; set; } // For Patient
        public string? Imagepath { get; set; }
        public IFormFile Image { get; set; }

    }
}
