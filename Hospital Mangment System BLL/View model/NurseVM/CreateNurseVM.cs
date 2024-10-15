using Hospital_Mangment_System_DAL.Entites;
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
        public Department? Department { get; set; }
    }
}
