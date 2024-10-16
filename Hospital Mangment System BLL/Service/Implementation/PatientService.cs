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
using Hospital_Mangment_System_BLL.Helper;

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

        public async Task<bool> AddAsync(CreatePatientVM patientVm)
        {

            var patient = _mapper.Map<Patient>(patientVm);
            return await _patientsRepo.AddAsync(patient);

            if (patientvm != null)
            {
               
                var result=_mapper.Map<Patient>(patientvm);
                if (patientvm.Image != null)
                {
                    result.Imagepath = Upload.UploadFile("Profile", patientvm.Image);
                }

                _patientsRepo.add(result);
                return true;
            }
            else return false;
          


        }

        public async Task<bool> DeleteAsync(string id)
        {
            return await _patientsRepo.DeleteAsync(id);
        }

        public async Task<List<GetAllPatientssVM>> GetAllAsync()
        {
            var patients = await _patientsRepo.GetAllAsync();
            return _mapper.Map<List<GetAllPatientssVM>>(patients);
        }

        public async Task<GetPatientByIdVM> GetByIdAsync(string id)
        {
            var patient = await _patientsRepo.GetByIdAsync(id);
            return _mapper.Map<GetPatientByIdVM>(patient);
        }

        public async Task<bool> UpdateAsync(UpdatePatientVM patientVm)
        {

            var patient = _mapper.Map<Patient>(patientVm);
            return await _patientsRepo.UpdateAsync(patient);




            if (patientvm != null)
            {
                var result = _mapper.Map<Patient>(patientvm);
                if (patientvm.Image != null)
                {
                    result.Imagepath = Upload.UploadFile("Profile", patientvm.Image);
                }

                
               


                _patientsRepo.update(result);
                return true;
            }
            else return false;



        }
    }
}
