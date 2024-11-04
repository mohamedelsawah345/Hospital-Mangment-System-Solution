using Hospital_Mangment_System_BLL.View_model.NurseVM;

namespace Hospital_Mangment_System_BLL.Service.Abstrsction
{
    public interface INurseService
    {
        Task<bool> AddAsync(CreateNurseVM nursevm);
        Task<bool> DeleteAsync(string nurseId);
        Task<List<GetAllNursesVM>> GetAllAsync();
        Task<GetNurseByIdVM> GetByIdAsync(string nurseId);
        Task<bool> UpdateAsync(UpdateNurseVM nursevm);
    }
}
