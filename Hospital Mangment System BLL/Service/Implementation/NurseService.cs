using AutoMapper;
using Hospital_Mangment_System_BLL.Helper;
using Hospital_Mangment_System_BLL.Service.Abstrsction;
using Hospital_Mangment_System_BLL.View_model.DepartmentVM;
using Hospital_Mangment_System_BLL.View_model.NurseVM;
using Hospital_Mangment_System_DAL.Entites;
using Hospital_Mangment_System_DAL.Repositary.Abstraction;
using Hospital_Mangment_System_DAL.Repositary.Implementation;

namespace Hospital_Mangment_System_BLL.Service.Implementation
{
    public class NurseService : INurseService
    {
        private readonly INurseRepo _nurseRepo;
        private readonly IMapper _mapper;

        public NurseService(INurseRepo nurseRepo, IMapper mapper) // Dependency Injection
        {
            _nurseRepo = nurseRepo;
            _mapper = mapper;
        }

        // Add new Nurse
        public async Task<bool> AddAsync(CreateNurseVM nursevm)
        {
            if (nursevm != null)
            {

                var result = _mapper.Map<Nurse>(nursevm);
                return await _nurseRepo.AddAsync(result);
            }
            return false;
        }

        // Delete Nurse by ID
        public async Task<bool> DeleteAsync(string nurseId)
        {
            return await _nurseRepo.DeleteAsync(nurseId);
        }

        // Get all Nurses
        public async Task<List<GetAllNursesVM>> GetAllAsync()
        {
            var result = await _nurseRepo.GetAllAsync();
            return _mapper.Map<List<GetAllNursesVM>>(result);
        }

        // Get Nurse by ID
        public async Task<GetNurseByIdVM> GetByIdAsync(string nurseId)
        {
            var result = await _nurseRepo.GetByIdAsync(nurseId);
            return _mapper.Map<GetNurseByIdVM>(result);
        }

        // Update Nurse
        public async Task<bool> UpdateAsync(UpdateNurseVM nursevm)
        {
            if (nursevm != null)
            {
                var result = _mapper.Map<Nurse>(nursevm);

                return await _nurseRepo.UpdateAsync(result);
            }
            return false;
        }
    }
}

