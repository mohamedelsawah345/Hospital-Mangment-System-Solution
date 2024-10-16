using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_Mangment_System_DAL.Entites
{
    public class Department
    {
        [Key]
        public int Dnum { get; set; }
        public string Dname { get; set; }
        public string Location { get; set; }
        public bool? IsDeleted { get; set; }
        public string? ManagerId { get; set; }

        // Navigation property - The doctor managing this department
        [ForeignKey("ManagerId")]
        public virtual Doctor Manager { get; set; }
        public List<Doctor>? Doctors { get; set; }
        public List<Nurse>? nurses { get; set; }
        public List<Medical_equipment> medical_Equipments { get; set; }


    }
}
