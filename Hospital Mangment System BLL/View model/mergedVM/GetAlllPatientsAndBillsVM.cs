using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Mangment_System_BLL.View_model.mergedVM
{
     public  class GetAlllPatientsAndBillsVM
    {
        public int Amount { get; set; }
        public DateOnly DateOfIssue { get; set; }
        public string PatientName { get; set; }
    }
}
