using Hospital_Mangment_System_DAL.DB;
using Hospital_Mangment_System_DAL.Entites;
using Hospital_Mangment_System_DAL.Repositary.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Mangment_System_DAL.Repositary.Implementation
{
    
    
        public class appointmentRepo : IappointmentRepo
        {
            private readonly ApplicationDBcontext _DBcontext;
            public appointmentRepo(ApplicationDBcontext DBcontext)
            {
                _DBcontext = DBcontext;
            }



            public bool add(Appointment appointment)
            {
                var result = _DBcontext.appointments.Add(appointment);


                if (result != null)
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

                var result = _DBcontext.appointments.Where(P => P.Appointment_Id == id).FirstOrDefault();  
               

                if (result != null)
                {
                     result.IsDeleted = true;
                    _DBcontext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }


            }

            public List<Appointment> getAll()
            {

                return _DBcontext.appointments.ToList();

            }

            public Appointment getbyId(int id)
            {
                return _DBcontext.appointments.Where(p => p.Appointment_Id == id).FirstOrDefault(); 


            }

            public bool update(Appointment appointment)
            {
            var result = _DBcontext.appointments.Where(p => p.Appointment_Id == appointment.Appointment_Id).FirstOrDefault();
            if (result != null)
            {
                result.Date = appointment.Date;
                result.timeOftheappointment = appointment.timeOftheappointment;
                result.Reason_Of_Visit = appointment.Reason_Of_Visit;
                result.patient_id = appointment.patient_id;

               
                _DBcontext.SaveChanges();
                return true;
            }

            return false; 
        }




    }
    }


