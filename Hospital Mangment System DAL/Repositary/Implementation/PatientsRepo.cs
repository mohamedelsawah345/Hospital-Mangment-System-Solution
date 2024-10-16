using Hospital_Mangment_System_DAL.DB;
using Hospital_Mangment_System_DAL.Entites;
using Hospital_Mangment_System_DAL.Repositary.Abstraction;
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



        public bool add(Patient patient)
        {
           
           
            try
            {
                var result = _DBcontext.patients.Add(patient);
                _DBcontext.SaveChanges();
                    return true;
                

            }
            catch (Exception ex)
            {
               
                return false;
               
            }

         
        }

        public bool delete(int id)
        {

          


            try
            {
                var result = _DBcontext.patients.Where(p => p.Id == id).FirstOrDefault(); //don't forget frist or defualt 

                result.IsDeleted = true;
                _DBcontext.SaveChanges();
                return true;


            }
            catch (Exception ex)
            {

                return false;

            }

           


        }

        public List<Patient> getAll()
        {
            try
            {
                return _DBcontext.patients.Where(p => p.IsDeleted != true).ToList();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding equipment: {ex.Message}");
                return new List<Patient>();

            }

        }

        public Patient getbyId(int id)
        {


            try
            {
                return _DBcontext.patients.Where(p => p.Id == id).FirstOrDefault(); //don't forget frist or defualt 


            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding equipment: {ex.Message}");
                return new Patient();

            }

        }

        public bool update(Patient patient)
        {
          var result= _DBcontext.patients.Where(p=>p.Id== patient.Id).FirstOrDefault(); //don't forget frist or defualt 

            try
            {

                result.phone1 = patient.phone1;
                result.phone2 = patient.phone2;
                result.Imagepath = patient.Imagepath;

                _DBcontext.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;

            }


            
        }
    }
}
