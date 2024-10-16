using Hospital_Mangment_System_DAL.DB;
using Hospital_Mangment_System_DAL.Entites;
using Hospital_Mangment_System_DAL.Repositary.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Mangment_System_DAL.Repositary.Implementation
{
    public class NurseRepo : INurseRepo
    {
        private readonly ApplicationDBcontext _DBcontext;

        public NurseRepo(ApplicationDBcontext DBcontext)
        {
            _DBcontext = DBcontext;
        }

        // Add new Nurse
        public async Task<bool> AddAsync(Nurse nurse)
        {
            try
            {
                var applicationUser = await _DBcontext.Users.FindAsync(nurse.ApplicationUserId);
                if (applicationUser != null)
                {
                    await _DBcontext.nurses.AddAsync(nurse);
                    await _DBcontext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding nurse: {ex.Message}");
                return false;
            }
        }

        // Delete Nurse by ID
        public async Task<bool> DeleteAsync(string nurseId)
        {
            try
            {
                var nurse = await _DBcontext.nurses.FirstOrDefaultAsync(n => n.ApplicationUserId == nurseId);
                if (nurse != null)
                {
                    nurse.IsDeleted = true;
                    await _DBcontext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting nurse: {ex.Message}");
                return false;
            }
        }
        // Get all Nurses
        public async Task<List<Nurse>> GetAllAsync()
        {
            try
            {
                return await _DBcontext.nurses.Include(n => n.Department).Where(p => !p.IsDeleted).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching nurses: {ex.Message}");
                return new List<Nurse>();
            }
        }

        // Get Nurse by ID
        public async Task<Nurse> GetByIdAsync(string nurseId)
        {
            try
            {
                return await _DBcontext.nurses.Include(n => n.Department)
                                              .FirstOrDefaultAsync(n => n.ApplicationUserId == nurseId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching nurse by ID: {ex.Message}");
                return null;
            }
        }

        // Update Nurse
        public async Task<bool> UpdateAsync(Nurse nurse)
        {
            try
            {
                // Fetch the existing nurse from the database using ApplicationUserId
                var existingNurse = await _DBcontext.nurses.FirstOrDefaultAsync(n => n.ApplicationUserId == nurse.ApplicationUserId);
                if (existingNurse != null)
                {
                    existingNurse.Phone = nurse.Phone;
                    existingNurse.Dnum = nurse.Dnum;              
                    await _DBcontext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating nurse: {ex.Message}");
                return false;
            }
        }
    }
}

