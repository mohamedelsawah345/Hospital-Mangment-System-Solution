using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Mangment_System_DAL.Entites
{
    public class Medical_equipment
    {
        [Key]
        public int Equipment_Id { get; set; }
        public string Equip_name { get; set; }
        public DateTime Maintence_date { get; set; }
        public bool? IsDeleted { get; set; }
        public int Dnum { get; set; }
        public Department Department { get; set; }
    }
}
