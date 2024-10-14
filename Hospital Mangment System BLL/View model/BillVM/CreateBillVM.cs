using Hospital_Mangment_System_DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Mangment_System_BLL.View_model.BillVM
{
    public  class CreateBillVM
    {
        public int ID { get; set; }
        public int Amount { get; set; }
        public DateOnly DateOfIssue { get; set; }
        public int PatientId { get; set; }

    }
}
