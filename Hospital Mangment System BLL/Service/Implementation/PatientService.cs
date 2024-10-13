using Hospital_Mangment_System_BLL.Service.Abstrsction;
using Hospital_Mangment_System_DAL.Repositary.Implementation;
using Hospital_Mangment_System_BLL.View_model.patientVM;
using Hospital_Mangment_System_DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital_Mangment_System_DAL.DB;
using Hospital_Mangment_System_DAL.Repositary.Abstraction;
using AutoMapper;

namespace Hospital_Mangment_System_BLL.Service.Implementation
{
    public class PatientService : IPatientService
    {
       private readonly IPatientsRepo _patientsRepo;
       private readonly IMapper _mapper;

        public PatientService(IPatientsRepo patientsRepo,IMapper mapper) //Dependsncy InJection 
        {
            _patientsRepo = patientsRepo;   
            _mapper = mapper;
        }

        public bool add(CreatePatientVM patientvm)
        {
            if (patientvm != null)
            {
               
                var result=_mapper.Map<Patient>(patientvm);

                _patientsRepo.add(result);
                return true;
            }
            else return false;
          

        }

        public bool delete(int id)
        {

            if (_patientsRepo.delete(id))
            {
                return true;
            }
            else return false;            
           
        }

        public List<GetAllPatientsVM> getAll()
        {

            var result = _patientsRepo.getAll().ToList();
            var newData= _mapper.Map< List<GetAllPatientsVM>>(result);

            return newData;

        }

        public GetPatientByIdVM getbyId(int id)
        {
            var result = _patientsRepo.getbyId(id);
            var newdata= _mapper.Map<GetPatientByIdVM>( result);

            return newdata;
        }

        public bool update(UpdatePatientVM patientvm)
        {



            if (patientvm != null)
            {

                var result = _mapper.Map<Patient>(patientvm);

                _patientsRepo.update(result);
                return true;
            }
            else return false;


        }
    }
}
