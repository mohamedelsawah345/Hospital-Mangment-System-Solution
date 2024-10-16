using Hospital_Mangment_System_DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Mangment_System_DAL.Repositary.Abstraction
{
    public interface INurseRepo
    {
        Task<bool> AddAsync(Nurse nurse);
        Task<bool> DeleteAsync(string NurseID);
        Task<List<Nurse>> GetAllAsync();
        Task<Nurse> GetByIdAsync(string NurseID);
        Task<bool> UpdateAsync(Nurse nurse);
    }
}
