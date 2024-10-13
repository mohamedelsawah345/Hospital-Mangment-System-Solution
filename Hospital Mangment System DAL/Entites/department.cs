using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Mangment_System_DAL.Entites
{
    public class Department
    {
        [Key]
        public int Dnum { get; set; }
        public int Dname { get; set; }
        public string Location { get; set; }
        public int Dr_Id { get; set; }
        public int? ManagerId { get; set; }

        // Navigation property - The doctor managing this department
        [ForeignKey("ManagerId")]
        public virtual Doctor Manager { get; set; }
        public List<Doctor>? Doctors { get; set; }
        public List<Nurse>? nurses { get; set; }
        public List<Medical_equipment> medical_Equipments { get; set; }


    }
}
