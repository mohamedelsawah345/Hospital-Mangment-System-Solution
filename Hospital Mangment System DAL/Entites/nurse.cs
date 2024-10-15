using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Mangment_System_DAL.Entites
{
    public class Nurse
    {
        [Key]
        public int NurseID { get; set; }
        public string Name { get; set; }
        public long phones { get; set; }
        public bool? IsDeleted { get; set; }
        public int Dnum { get; set; }
        public Department? Department { get; set; }

    }
}
