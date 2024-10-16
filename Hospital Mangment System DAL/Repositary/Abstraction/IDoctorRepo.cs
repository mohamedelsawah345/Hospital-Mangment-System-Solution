using Hospital_Mangment_System_DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Mangment_System_DAL.Repositary.Abstraction
{
    public interface IDoctorRepo
    {
        Task<bool> AddAsync(Doctor doctor);
        Task<bool> DeleteAsync(string id);
        Task<List<Doctor>> GetAllAsync();
        Task<Doctor> GetByIdAsync(string id); 
        Task<bool> UpdateAsync(Doctor doctor);
    }
}
