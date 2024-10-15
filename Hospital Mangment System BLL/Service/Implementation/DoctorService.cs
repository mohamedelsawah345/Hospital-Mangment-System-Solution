using AutoMapper;
using Hospital_Mangment_System_BLL.Service.Abstrsction;
using Hospital_Mangment_System_BLL.View_model.DoctorVM;
using Hospital_Mangment_System_BLL.View_model.patientVM;
using Hospital_Mangment_System_DAL.Entites;
using Hospital_Mangment_System_DAL.Repositary.Abstraction;
using Hospital_Mangment_System_DAL.Repositary.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Mangment_System_BLL.Service.Implementation
{
    public class DoctorService : IDoctorService
    {

        private readonly IDoctorRepo _DoctorRepo;
        private readonly IMapper _mapper;

        public DoctorService(IDoctorRepo DoctorRepo, IMapper mapper) //Dependsncy InJection 
        {
            _DoctorRepo = DoctorRepo;
            _mapper = mapper;
        }

        public bool add(CreateDoctorVM doctorvm)
        {
            if (doctorvm != null)
            {

                var result = _mapper.Map<Doctor>(doctorvm);

                _DoctorRepo.add(result);
                return true;
            }
            else return false;

        }

        public bool delete(int id)
        {
            if (_DoctorRepo.delete(id))
            {
                return true;
            }
            else return false;
        }

        public List<GetAllDoctorVM> getAll()
        {

            var result = _DoctorRepo.getAll().ToList();
            var newData = _mapper.Map<List<GetAllDoctorVM>>(result);

            return newData;

        }

        public GetDoctorByIdVM getbyId(int id)
        {
            var result = _DoctorRepo.getbyId(id);
            var newdata = _mapper.Map<GetDoctorByIdVM>(result);

            return newdata;
        }

        public bool update(UpdateDoctorVM doctorvm)
        {

            if (doctorvm != null)
            {

                var result = _mapper.Map<Doctor>(doctorvm);

                _DoctorRepo.update(result);
                return true;
            }
            else return false;
        }
    }
}
