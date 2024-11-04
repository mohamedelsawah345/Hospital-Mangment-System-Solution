using Hospital_Mangment_System_DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Mangment_System_DAL.Repositary.Abstraction
{
    public interface IPatientsRepo
    {
        Task<bool> AddAsync(Patient patient);
        Task<bool> DeleteAsync(string id);
        Task<List<Patient>> GetAllAsync();
        Task<Patient> GetByIdAsync(string id);
        Task<bool> UpdateAsync(Patient patient);

    }
}
