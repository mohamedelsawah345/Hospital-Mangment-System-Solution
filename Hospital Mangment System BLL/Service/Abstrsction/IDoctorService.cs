using Hospital_Mangment_System_BLL.View_model.DoctorVM;


namespace Hospital_Mangment_System_BLL.Service.Abstrsction
{
    public interface IDoctorService
    {

        Task<bool> AddAsync(CreateDoctorVM doctorvm);
        Task<bool> DeleteAsync(string id);
        Task<List<GetAllDoctorVM>> GetAllAsync();
        Task<GetDoctorByIdVM> GetByIdAsync(string id);
        Task<bool> UpdateAsync(UpdateDoctorVM doctorvm);
        Task<bool> IsUsernameUnique(string username);
    }
}
