using Hospital_Mangment_System_DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Mangment_System_BLL.View_model
{
    public  class GetEquipmentByIdVM
    {
        public int Equipment_Id { get; set; }
        public string Equip_name { get; set; }
        public DateTime Maintence_date { get; set; }
        public int Dnum { get; set; }
        public bool? IsDeleted { get; set; }
        public Department Department { get; set; }

    }
}
