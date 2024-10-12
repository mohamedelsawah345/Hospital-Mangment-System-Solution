using AutoMapper;
using Hospital_Mangment_System_BLL.View_model.patientVM;
using Hospital_Mangment_System_DAL.Entites;

namespace Hospital_Mangment_System_BLL.Mapping
{
    public class MyProfile :Profile //profile exist in AutoMapper
    {
        public MyProfile()
        {
            CreateMap<CreatePatientVM, patient>();
            CreateMap<patient, GetPatientByIdVM>(); // Don't forger this to tell utomaber how work
            CreateMap<patient, GetAllPatientsVM>();
            CreateMap<UpdatePatientVM, patient>();




        }


    }
}
