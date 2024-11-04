using Hospital_Mangment_System_DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Mangment_System_BLL.View_model
{
    public class GetAllEquipmentVM
    {
        public int Equipment_Id { get; set; }
        public string Equip_name { get; set; }
        public DateTime Maintence_date { get; set; }
        public int Dnum { get; set; }
        public string DepartmentName { get; set; }

    }
}
