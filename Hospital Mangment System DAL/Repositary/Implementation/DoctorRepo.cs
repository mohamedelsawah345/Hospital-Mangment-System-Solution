using Hospital_Mangment_System_DAL.DB;
using Hospital_Mangment_System_DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Mangment_System_DAL.Repositary.Implementation
{
    public  class DoctorRepo
    {

        private readonly ApplicationDBcontext _DBcontext;
        public DoctorRepo(ApplicationDBcontext DBcontext)
        {
            _DBcontext = DBcontext;
        }



        public bool add(Doctor doctor)
        {


            try
            {
                var result = _DBcontext.Doctors.Add(doctor);
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
                var result = _DBcontext.Doctors.Where(p => p.DrId == id).FirstOrDefault(); //don't forget frist or defualt 

                result.IsDeleted = true;
                _DBcontext.SaveChanges();
                return true;


            }
            catch (Exception ex)
            {

                return false;

            }
        }

        public List<Doctor> getAll()
        {
            try
            {
                return _DBcontext.Doctors.Where(p => p.IsDeleted != true).ToList();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding equipment: {ex.Message}");
                return new List<Doctor>();

            }

        }

        public Doctor getbyId(int id)
        {


            try
            {
                return _DBcontext.Doctors.Where(p => p.DrId == id).FirstOrDefault(); //don't forget frist or defualt 


            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding equipment: {ex.Message}");
                return new Doctor();

            }

        }

        public bool update(Doctor doctor)
        {
            var result = _DBcontext.Doctors.Where(p => p.DrId == doctor.DrId).FirstOrDefault(); //don't forget frist or defualt 

            try
            {

                result.Phone = doctor.Phone;
               

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

