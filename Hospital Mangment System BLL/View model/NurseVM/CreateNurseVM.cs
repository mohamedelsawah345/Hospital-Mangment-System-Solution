using Hospital_Mangment_System_DAL.Entites;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Mangment_System_BLL.View_model.NurseVM
{
    public class CreateNurseVM
    {
        public int NurseID { get; set; }
        public string Name { get; set; }
        public long phones { get; set; }
        public int Dnum { get; set; }
        public string? Imagepath { get; set; }
        public IFormFile Image { get; set; }
        public Department? Department { get; set; }
    }
}
