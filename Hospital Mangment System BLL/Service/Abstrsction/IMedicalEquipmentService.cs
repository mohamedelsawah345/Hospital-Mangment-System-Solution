using Hospital_Mangment_System_BLL.View_model;
using Hospital_Mangment_System_DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Mangment_System_BLL.Service.Abstrsction
{
    public interface IMedicalEquipmentService
    {

        public bool add(CreateEquipmentVM medical_Equipment);
        public bool delete(int Equipment_Id);

        public bool update(UpdateEquipmentVM medical_Equipment);

        public GetEquipmentByIdVM getbyId(int Equipment_Id);

        public List<GetAllEquipmentVM> getAll();

    }
}
