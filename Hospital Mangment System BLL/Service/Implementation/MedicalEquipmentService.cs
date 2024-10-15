using AutoMapper;
using Hospital_Mangment_System_BLL.View_model;
using Hospital_Mangment_System_BLL.View_model.patientVM;
using Hospital_Mangment_System_DAL.DB;
using Hospital_Mangment_System_DAL.Entites;
using Hospital_Mangment_System_DAL.Repositary.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using Hospital_Mangment_System_BLL.Service.Abstrsction;
using Hospital_Mangment_System_BLL.Service.Implementation;
using Hospital_Mangment_System_BLL.View_model.BillVM;
namespace Hospital_Mangment_System_BLL.View_model
{
    public class MedicalEquipmentService : IMedicalEquipmentService
    {
        private readonly IMedicalEquipmentRepo _MedicalService;
        private readonly IMapper _mapper;

        public MedicalEquipmentService(IMedicalEquipmentRepo MedicalService, IMapper mapper)
        {
            _MedicalService = MedicalService;
            _mapper = mapper;
        }

        public bool add(CreateEquipmentVM medicalEquipment)
        {
            if (medicalEquipment != null)
            {

                var result = _mapper.Map<Medical_equipment>(medicalEquipment);

                _MedicalService.add(result);
                return true;
            }
            else return false;

        }

        public bool delete(int id)
        {
            return _MedicalService.delete(id);
        }

        public List<GetAllEquipmentVM> getAll()
        {
            var result = _MedicalService.getAll().Where(a => a.IsDeleted != true).ToList();
            var newData = _mapper.Map<List<GetAllEquipmentVM>>(result);
            return newData;
        }
        public GetEquipmentByIdVM getbyId(int Equipment_Id)
        {
            var res = _MedicalService.getbyId(Equipment_Id);
            var newData = _mapper.Map<GetEquipmentByIdVM>(res);
            return newData; ;
        }

        public bool update(UpdateEquipmentVM medicalEquipment)
        {
            var medicalentity = _mapper.Map<Medical_equipment>(medicalEquipment);
            return _MedicalService.update(medicalentity);
        }
    }

}
