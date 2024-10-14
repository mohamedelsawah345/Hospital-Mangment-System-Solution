using AutoMapper;
using Hospital_Mangment_System_BLL.Service.Abstrsction;
using Hospital_Mangment_System_BLL.View_model.patientVM;
using Hospital_Mangment_System_DAL.Entites;
using Hospital_Mangment_System_DAL.Repositary.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Mangment_System_BLL.Service.Implementation
{
    public class Equipmentservice : IEquipmentService
    {
        private readonly IEquipmentService equipmentService1;
        private readonly IMapper _mapper;

        public Equipmentservice(IEquipmentService equipmentService, IMapper mapper) 
        {
            equipmentService = equipmentService;
            _mapper = mapper;
        }

        public bool add(CreateEquipmentVM equiptvm)
        {
            if (equiptvm != null)
            {

                var result = _mapper.Map<Medical_equipment>(equiptvm);

                equipmentService1.add(result);
                return true;
            }
            else return false;


        }

        public bool add(Medical_equipment medical_Equipment)
        {
            throw new NotImplementedException();
        }

        public void add(Patient result)
        {
            throw new NotImplementedException();
        }

        public bool delete(int Equipment_id)
        {

            if (equipmentService1.delete(Equipment_id))
            {
                return true;
            }
            else return false;

        }

        public List<GetAllEquipmentsVM> getAll()
        {

            var result = equipmentService1.getAll().ToList();
            var newData = _mapper.Map<List<GetAllEquipmentsVM>>(result);

            return newData;

        }

        public GetEquipmentsByIdVM getbyId(int Equipment_id)
        {
            var result = equipmentService1.getbyId(Equipment_id);
            var newdata = _mapper.Map<GetEquipmentsByIdVM>(result);

            return newdata;
        }

        public bool update(UpdateEquipmentVM equipmentVM)
        {



            if (equipmentVM != null)
            {

                var result = _mapper.Map<Medical_equipment>(equipmentVM);

                equipmentService1.update(result);
                return true;
            }
            else return false;


        }

        public bool update(Medical_equipment medical_Equipment)
        {
            throw new NotImplementedException();
        }

        public void update(Patient result)
        {
            throw new NotImplementedException();
        }

        List<Medical_equipment> IEquipmentService.getAll()
        {
            throw new NotImplementedException();
        }

        Bill IEquipmentService.getbyId(int Equipment_Id)
        {
            throw new NotImplementedException();
        }
    }
}

