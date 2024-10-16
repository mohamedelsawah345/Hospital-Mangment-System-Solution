using Hospital_Mangment_System_DAL.Entites;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Mangment_System_BLL.View_model.patientVM
{
    public class UpdatePatientVM
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public int phone1 { get; set; }
        public int? phone2 { get; set; }
        public string? Imagepath { get; set; }
        public IFormFile Image { get; set; }

    }

}
