using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Mangment_System_DAL.Entites
{
    public class Bill
    {
        public int ID { get; set; }

        public int Amount { get; set; }
        public bool? IsDeleted { get; set; }

        public DateOnly DateOfIssue { get; set; }

        [ForeignKey("patientId")]
        public Patient patient { get; set; }

        public int patientId { get; set; }

    }
}
