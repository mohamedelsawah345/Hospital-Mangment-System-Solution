using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Mangment_System_BLL.View_model.BillVM
{
    public  class GetAllBillsVM
    {
        public int ID { get; set; }
        public int Amount { get; set; }
        public bool IsDeleted { get; set; }
        public DateOnly DateOfIssue { get; set; }
        public int PatientId { get; set; }
    }
}
