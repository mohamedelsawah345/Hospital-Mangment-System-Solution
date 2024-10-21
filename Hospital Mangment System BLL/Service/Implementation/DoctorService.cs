using AutoMapper;
using Hospital_Mangment_System_BLL.Service.Abstrsction;
using Hospital_Mangment_System_BLL.View_model.DoctorVM;
using Hospital_Mangment_System_BLL.View_model.patientVM;
using Hospital_Mangment_System_DAL.Entites;
using Hospital_Mangment_System_DAL.Repositary.Abstraction;
using Hospital_Mangment_System_DAL.Repositary.Implementation;
using Microsoft.EntityFrameworkCore;
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

        public DoctorService(IDoctorRepo DoctorRepo, IMapper mapper) // Dependency Injection 
        {
            _DoctorRepo = DoctorRepo;
            _mapper = mapper;
        }

        public async Task<bool> AddAsync(CreateDoctorVM doctorvm)
        {
            if (doctorvm != null)
            {
                var result = _mapper.Map<Doctor>(doctorvm);
                return await _DoctorRepo.AddAsync(result);
            }
            return false;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            return await _DoctorRepo.DeleteAsync(id);
        }

        public async Task<List<GetAllDoctorVM>> GetAllAsync()
        {
            var result = await _DoctorRepo.GetAllAsync(); 
            var newData = _mapper.Map<List<GetAllDoctorVM>>(result);
            return newData;
        }

        public async Task<GetDoctorByIdVM> GetByIdAsync(string id)
        {
            var result = await _DoctorRepo.GetByIdAsync(id); 
            var newData = _mapper.Map<GetDoctorByIdVM>(result);
            return newData;
        }

        public async Task<bool> IsUsernameUnique(string username)
        {
            return !await _DoctorRepo.IsUsernameUnique(username);
        }

        public async Task<bool> UpdateAsync(UpdateDoctorVM doctorvm)
        {
            if (doctorvm != null)
            {
                var result = _mapper.Map<Doctor>(doctorvm);
                return await _DoctorRepo.UpdateAsync(result);
            }
            return false;
        }
    }
}
