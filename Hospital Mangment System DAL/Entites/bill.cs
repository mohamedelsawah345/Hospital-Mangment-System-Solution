using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Mangment_System_DAL.Entites
{
    public class bill
    {
        public int ID { get; set; }

        public int Amount { get; set; }
        public bool? IsDeleted { get; set; }

        public DateOnly DateOfIssue { get; set; }

        [ForeignKey("patientId")]
        public patient patient { get; set; }

        public int patientId { get; set; }

    }
}
