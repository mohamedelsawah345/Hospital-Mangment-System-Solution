using Hospital_Mangment_System_DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Mangment_System_DAL.Repositary.Abstraction
{
    public  interface IMedicalEquipmentRepo
    {
        public bool add(Medical_equipment medical_Equipment);
        public bool delete(int Equipment_Id);

        public bool update(Medical_equipment medical_Equipment);

        public Medical_equipment getbyId(int Equipment_Id);

        public List<Medical_equipment> getAll();

    }
}
