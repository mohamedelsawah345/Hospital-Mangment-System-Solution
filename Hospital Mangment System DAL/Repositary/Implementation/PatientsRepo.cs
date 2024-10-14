using Hospital_Mangment_System_DAL.DB;
using Hospital_Mangment_System_DAL.Entites;
using Hospital_Mangment_System_DAL.Repositary.Abstraction;
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
            var result = _DBcontext.patients.Add(patient);
           

            if (result!=null)
            {
                _DBcontext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool delete(int id)
        {

          var result= _DBcontext.patients.Where(p=>p.Id==id).FirstOrDefault(); //don't forget frist or defualt 
            

            if (result != null)
            {
                _DBcontext.Remove(result);  
                _DBcontext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }


        }

        public List<Patient> getAll()
        {
        
                return _DBcontext.patients.ToList();

        }

        public Patient getbyId(int id)
        {
            return _DBcontext.patients.Where(p => p.Id == id).FirstOrDefault(); //don't forget frist or defualt 


        }

        public bool update(Patient patient)
        {
          var result= _DBcontext.patients.Where(p=>p.Id== patient.Id).FirstOrDefault(); //don't forget frist or defualt 

           

            if (result != null)
            {
               
                result.phone1 = patient.phone1;
                result.phone2 = patient.phone2;
               
                _DBcontext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
