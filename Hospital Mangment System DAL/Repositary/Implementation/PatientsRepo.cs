using Hospital_Mangment_System_DAL.DB;
using Hospital_Mangment_System_DAL.Entites;
using Hospital_Mangment_System_DAL.Repositary.Abstraction;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Mangment_System_DAL.Repositary.Implementation
{
    public class PatientsRepo : IPatientsRepo
    {
        private readonly ApplicationDBcontext _DBcontext;

        public PatientsRepo(ApplicationDBcontext DBcontext)
        {
            _DBcontext = DBcontext;
        }

        public async Task<bool> AddAsync(Patient patient)
        {
            try
            {
                await _DBcontext.patients.AddAsync(patient);
                await _DBcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                return false;
            }
        }

        public async Task<bool> DeleteAsync(string id)
        {
            try
            {
                var result = await _DBcontext.patients.Where(d => d.ApplicationUserId == id).FirstOrDefaultAsync();

                if (result != null)
                {
                    result.IsDeleted = true;
                    await _DBcontext.SaveChangesAsync();
                    return true;
                }
                return false; // Patient not found
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                return false;
            }
        }

        public async Task<List<Patient>> GetAllAsync()
        {
            try
            {
                return await _DBcontext.patients.Where(p => p.IsDeleted != true).ToListAsync();
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                return new List<Patient>();
            }
        }

        public async Task<Patient> GetByIdAsync(string id)
        {
            try
            {
                return await _DBcontext.patients.Where(d => d.ApplicationUserId == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                return new Patient();
            }
        }

        public async Task<bool> UpdateAsync(Patient patient)
        {
            try
            {
                var result = await _DBcontext.patients.Where(d => d.ApplicationUserId == patient.ApplicationUserId).FirstOrDefaultAsync();


                if (result != null)
                {
                    result.Phone = patient.Phone;
                    await _DBcontext.SaveChangesAsync();
                    return true;
                }
                return false; // Patient not found
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                return false;
            }
        }
    }
}
