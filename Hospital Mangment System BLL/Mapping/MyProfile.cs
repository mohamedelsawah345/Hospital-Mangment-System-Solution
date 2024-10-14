using AutoMapper;
using Hospital_Mangment_System_BLL.View_model.AppointmentVM;
using Hospital_Mangment_System_BLL.View_model.patientVM;
using Hospital_Mangment_System_DAL.Entites;

namespace Hospital_Mangment_System_BLL.Mapping
{
    public class MyProfile :Profile //profile exist in AutoMapper
    {
        public MyProfile()
        {
            CreateMap<CreatePatientVM, Patient>();
            CreateMap<Patient, GetPatientByIdVM>(); // Don't forger this to tell utomaber how work
            CreateMap<Patient, GetAllPatientsVM>();
            CreateMap<UpdatePatientVM, Patient>();

            CreateMap<AddAppointmentVM, Appointment>();
            CreateMap<Appointment , GetAppointmentByIDVM>();
            CreateMap<Appointment, GetAllAppointmentVM>();
            CreateMap< UpdateAppointmentVM, Appointment>();




        }




    }
}
