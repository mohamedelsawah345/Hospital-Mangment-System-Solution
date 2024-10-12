using Hospital_Mangment_System_DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Mangment_System_BLL.View_model.patientVM
{
    public  class CreatePatientVM
    {

       
        public string Name { get; set; }

        public string Email { get; set; }
        public DateOnly birthday { get; set; }


        public int phone1 { get; set; }

        public int? phone2 { get; set; }

        public char Gender { get; set; }

     



    }
}
