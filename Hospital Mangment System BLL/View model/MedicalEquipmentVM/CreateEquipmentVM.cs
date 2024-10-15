using Hospital_Mangment_System_DAL.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Mangment_System_BLL.View_model
{
    public  class CreateEquipmentVM
    {
        [Required]
        public string Equip_name { get; set; }

        public DateTime? Maintence_date { get; set; }
        public bool IsDeleted { get; set; } = false;

        [Required]
        public int Dnum { get; set; }

        // Optionally include Department details if needed
        public Department? Department { get; set; }


    }
}
