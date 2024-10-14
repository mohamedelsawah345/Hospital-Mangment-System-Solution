using Hospital_Mangment_System_DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Mangment_System_BLL.Service.Abstrsction
{
    public interface IEquipmentService 
    {

        public bool add(Medical_equipment medical_Equipment);
        public bool delete(int Equipment_Id);

        public bool update(Medical_equipment medical_Equipment);

        public Bill getbyId(int Equipment_Id);

        public List<Medical_equipment> getAll();
        void add(Patient result);
        void update(Patient result);
    }
}
