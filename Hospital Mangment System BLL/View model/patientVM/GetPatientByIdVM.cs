using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Mangment_System_BLL.View_model.patientVM
{
    public  class GetPatientByIdVM
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public DateOnly birthday { get; set; }


        public int phone1 { get; set; }

        public int? phone2 { get; set; }

        public char Gender { get; set; }
        public string? Imagepath { get; set; }


    }
}
