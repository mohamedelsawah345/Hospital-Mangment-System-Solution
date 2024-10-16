using Hospital_Mangment_System_DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Mangment_System_BLL.View_model.patientVM
{
    public interface IPatientService
    {
        Task< bool> AddAsync(CreatePatientVM patient);
        Task< bool> DeleteAsync(string id);
        Task< bool> UpdateAsync(UpdatePatientVM patient);
        Task< GetPatientByIdVM> GetByIdAsync(string id);
        Task< List<GetAllPatientssVM>> GetAllAsync();
    }
}
