using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Mangment_System_DAL.Entites
{
    public class addmission
    {
        public int Addmission_Id { get; set; }
        public int room_number { get; set; }
        public DateOnly Addmission_Date { get; set; }
        public DateOnly Date_discharge { get; set; }
        public int Patient_Id { get; set; }

        public patient patient { get; set; } = null;//ameend test
    }
}
