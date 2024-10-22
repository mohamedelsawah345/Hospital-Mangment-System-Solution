using Hospital_Mangment_System_DAL.DB;
using Hospital_Mangment_System_DAL.Entites;
using Hospital_Mangment_System_DAL.Repositary.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Mangment_System_DAL.Repositary.Implementation
{
    public class DoctorRepo : IDoctorRepo
    {
        private readonly ApplicationDBcontext _DBcontext;

        public DoctorRepo(ApplicationDBcontext context)
        {
            _DBcontext = context;
        }

        //  add method
        public async Task<bool> AddAsync(Doctor doctor)
        {
            try
            {
                await _DBcontext.Doctors.AddAsync(doctor); 
                await _DBcontext.SaveChangesAsync(); 
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding doctor: {ex.Message}"); 
                return false;
            }
        }

        //  delete method
        public async Task<bool> DeleteAsync(string id)
        {
            try
            {
                
                var user = await _DBcontext.Users.FindAsync(id);
                if (user != null)
                {
                    user.IsDeleted = true;
                    await _DBcontext.SaveChangesAsync();
                    return true;  
                }
                return false;  
            }
            catch (Exception ex)
            {
                // Log the error (replace with proper logging in production)
                Console.WriteLine($"Error deleting user: {ex.Message}");
                return false;  // Return false if an exception occurred
            }
        }

        //  get all method
        public async Task<List<Doctor>> GetAllAsync()
        {
            try
            {
                return await _DBcontext.Doctors
            .Include(d => d.ApplicationUser)
            .Where(d => !d.ApplicationUser.IsDeleted) // Ensure only non-deleted users
            .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching doctors: {ex.Message}"); 
                return new List<Doctor>(); 
            }
        }

        //  get by ID method
        public async Task<Doctor> GetByIdAsync(string id)
        {
            try
            {
                return await _DBcontext.Doctors
            .Include(d => d.ApplicationUser)
            .FirstOrDefaultAsync(d => d.ApplicationUserId == id && !d.ApplicationUser.IsDeleted);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching doctor by ID: {ex.Message}"); 
                return null; 
            }
        }

        public async Task<bool> IsUsernameUnique(string username)
        {
            return !await _DBcontext.Users.AnyAsync(d => d.UserName == username);
        }


        //  update method
        public async Task<bool> UpdateAsync(Doctor doctor)
        {
            try
            {
                var existingDoctor = await _DBcontext.Doctors
                    .Where(p => p.ApplicationUserId == doctor.ApplicationUserId) 
                    .FirstOrDefaultAsync(); 

                if (existingDoctor == null)
                {
                    return false; 
                }

                // Update the properties
                existingDoctor.Phone = doctor.Phone;
                existingDoctor.Speciality = doctor.Speciality; 

                await _DBcontext.SaveChangesAsync(); 
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating doctor: {ex.Message}"); 
                return false;
            }
        }
    }
}





